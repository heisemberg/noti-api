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
public class SubModuloController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubModuloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubModuloDto>>> Get()
    {
        var sub = await _unitOfWork.SubModulos.GetAllAsync();

        return _mapper.Map<List<SubModuloDto>>(sub);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubModuloDto>> Get(int id){
        var sub = await _unitOfWork.SubModulos.GetByIdAsync(id);
        if (sub == null){
            return NotFound();
        }
        return _mapper.Map<SubModuloDto>(sub);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubModuloDto>> Post(SubModuloDto SubModuloDto){
        var sub = _mapper.Map<SubModulo>(SubModuloDto);
        _unitOfWork.SubModulos.Add(sub);
        await _unitOfWork.SaveAsync();
        if(sub == null){
            return BadRequest();
        }
        SubModuloDto.Id = sub.Id;
        return CreatedAtAction(nameof(Post), new {id = SubModuloDto.Id}, SubModuloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubModuloDto>> Put(int id, [FromBody]SubModuloDto SubModuloDto){
        if(SubModuloDto.Id == 0){
            SubModuloDto.Id = id;
        }

        if(SubModuloDto.Id != id){
            return BadRequest();
        }

        if(SubModuloDto == null){
            return NotFound();
        }
        var sub = _mapper.Map<SubModulo>(SubModuloDto);
        _unitOfWork.SubModulos.Update(sub);
        await _unitOfWork.SaveAsync();
        return SubModuloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var sub = await _unitOfWork.SubModulos.GetByIdAsync(id);
        if(sub == null){
            return NotFound();
        }
        _unitOfWork.SubModulos.Remove(sub);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}