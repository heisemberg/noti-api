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
public class GenericoVsSubmoduloController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericoVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericoVsSubmoduloDto>>> Get()
    {
        var generico = await _unitOfWork.GenericosVsSubmodulos.GetAllAsync();

        return _mapper.Map<List<GenericoVsSubmoduloDto>>(generico);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericoVsSubmoduloDto>> Get(int id){
        var generico = await _unitOfWork.GenericosVsSubmodulos.GetByIdAsync(id);
        if (generico == null){
            return NotFound();
        }
        return _mapper.Map<GenericoVsSubmoduloDto>(generico);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericoVsSubmoduloDto>> Post(GenericoVsSubmoduloDto GenericoVsSubmoduloDto){
        var generico = _mapper.Map<GenericoVsSubmodulo>(GenericoVsSubmoduloDto);
        _unitOfWork.GenericosVsSubmodulos.Add(generico);
        await _unitOfWork.SaveAsync();
        if(generico == null){
            return BadRequest();
        }
        GenericoVsSubmoduloDto.Id = generico.Id;
        return CreatedAtAction(nameof(Post), new {id = GenericoVsSubmoduloDto.Id}, GenericoVsSubmoduloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericoVsSubmoduloDto>> Put(int id, [FromBody]GenericoVsSubmoduloDto GenericoVsSubmoduloDto){
        if(GenericoVsSubmoduloDto.Id == 0){
            GenericoVsSubmoduloDto.Id = id;
        }

        if(GenericoVsSubmoduloDto.Id != id){
            return BadRequest();
        }

        if(GenericoVsSubmoduloDto == null){
            return NotFound();
        }
        var generico = _mapper.Map<GenericoVsSubmodulo>(GenericoVsSubmoduloDto);
        _unitOfWork.GenericosVsSubmodulos.Update(generico);
        await _unitOfWork.SaveAsync();
        return GenericoVsSubmoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var generico = await _unitOfWork.GenericosVsSubmodulos.GetByIdAsync(id);
        if(generico == null){
            return NotFound();
        }
        _unitOfWork.GenericosVsSubmodulos.Remove(generico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}