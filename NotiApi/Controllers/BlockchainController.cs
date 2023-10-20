using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotiApi.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NotiApi.Controllers;
public class BlockchainController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlockchainController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BlockchainDto>>> Get()
    {
        var block = await _unitOfWork.Blockchains.GetAllAsync();

        return _mapper.Map<List<BlockchainDto>>(block);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BlockchainDto>> Get(int id){
        var block = await _unitOfWork.Blockchains.GetByIdAsync(id);
        if (block == null){
            return NotFound();
        }
        return _mapper.Map<BlockchainDto>(block);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlockchainDto>> Post(BlockchainDto blockchainDto){
        var block = _mapper.Map<Blockchain>(blockchainDto);
        _unitOfWork.Blockchains.Add(block);
        await _unitOfWork.SaveAsync();
        if(block == null){
            return BadRequest();
        }
        blockchainDto.Id = block.Id;
        return CreatedAtAction(nameof(Post), new {id = blockchainDto.Id}, blockchainDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BlockchainDto>> Put(int id, [FromBody]BlockchainDto blockchainDto){
        if(blockchainDto.Id == 0){
            blockchainDto.Id = id;
        }

        if(blockchainDto.Id != id){
            return BadRequest();
        }

        if(blockchainDto == null){
            return NotFound();
        }
        var block = _mapper.Map<Blockchain>(blockchainDto);
        _unitOfWork.Blockchains.Update(block);
        await _unitOfWork.SaveAsync();
        return blockchainDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var block = await _unitOfWork.Blockchains.GetByIdAsync(id);
        if(block == null){
            return NotFound();
        }
        _unitOfWork.Blockchains.Remove(block);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}