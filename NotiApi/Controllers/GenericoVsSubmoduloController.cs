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
public class GenericoVsSubModuloController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericoVsSubModuloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericoVsSubModuloDto>>> Get()
    {
        var generico = await _unitOfWork.GenericosVsSubModulos.GetAllAsync();

        return _mapper.Map<List<GenericoVsSubModuloDto>>(generico);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericoVsSubModuloDto>> Get(int id){
        var generico = await _unitOfWork.GenericosVsSubModulos.GetByIdAsync(id);
        if (generico == null){
            return NotFound();
        }
        return _mapper.Map<GenericoVsSubModuloDto>(generico);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericoVsSubModuloDto>> Post(GenericoVsSubModuloDto GenericoVsSubModuloDto){
        var generico = _mapper.Map<GenericoVsSubModulo>(GenericoVsSubModuloDto);
        _unitOfWork.GenericosVsSubModulos.Add(generico);
        await _unitOfWork.SaveAsync();
        if(generico == null){
            return BadRequest();
        }
        GenericoVsSubModuloDto.Id = generico.Id;
        return CreatedAtAction(nameof(Post), new {id = GenericoVsSubModuloDto.Id}, GenericoVsSubModuloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericoVsSubModuloDto>> Put(int id, [FromBody]GenericoVsSubModuloDto GenericoVsSubModuloDto){
        if(GenericoVsSubModuloDto.Id == 0){
            GenericoVsSubModuloDto.Id = id;
        }

        if(GenericoVsSubModuloDto.Id != id){
            return BadRequest();
        }

        if(GenericoVsSubModuloDto == null){
            return NotFound();
        }
        var generico = _mapper.Map<GenericoVsSubModulo>(GenericoVsSubModuloDto);
        _unitOfWork.GenericosVsSubModulos.Update(generico);
        await _unitOfWork.SaveAsync();
        return GenericoVsSubModuloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var generico = await _unitOfWork.GenericosVsSubModulos.GetByIdAsync(id);
        if(generico == null){
            return NotFound();
        }
        _unitOfWork.GenericosVsSubModulos.Remove(generico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}