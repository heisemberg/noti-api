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
public class ModulosMaestroController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModulosMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModuloMaestroDto>>> Get()
    {
        var modulo = await _unitOfWork.ModulosMaestros.GetAllAsync();

        return _mapper.Map<List<ModuloMaestroDto>>(modulo);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloMaestroDto>> Get(int id){
        var modulo = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
        if (modulo == null){
            return NotFound();
        }
        return _mapper.Map<ModuloMaestroDto>(modulo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloMaestroDto>> Post(ModuloMaestroDto ModuloMaestroDto){
        var modulo = _mapper.Map<ModuloMaestro>(ModuloMaestroDto);
        _unitOfWork.ModulosMaestros.Add(modulo);
        await _unitOfWork.SaveAsync();
        if(modulo == null){
            return BadRequest();
        }
        ModuloMaestroDto.Id = modulo.Id;
        return CreatedAtAction(nameof(Post), new {id = ModuloMaestroDto.Id}, ModuloMaestroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloMaestroDto>> Put(int id, [FromBody]ModuloMaestroDto ModuloMaestroDto){
        if(ModuloMaestroDto.Id == 0){
            ModuloMaestroDto.Id = id;
        }

        if(ModuloMaestroDto.Id != id){
            return BadRequest();
        }

        if(ModuloMaestroDto == null){
            return NotFound();
        }
        var modulo = _mapper.Map<ModuloMaestro>(ModuloMaestroDto);
        _unitOfWork.ModulosMaestros.Update(modulo);
        await _unitOfWork.SaveAsync();
        return ModuloMaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var modulo = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
        if(modulo == null){
            return NotFound();
        }
        _unitOfWork.ModulosMaestros.Remove(modulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}