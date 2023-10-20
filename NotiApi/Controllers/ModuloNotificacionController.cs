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
public class ModuloNotificacionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuloNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModuloNotificacionDto>>> Get()
    {
        var modulo = await _unitOfWork.ModuloNotificaciones.GetAllAsync();

        return _mapper.Map<List<ModuloNotificacionDto>>(modulo);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionDto>> Get(int id){
        var modulo = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);
        if (modulo == null){
            return NotFound();
        }
        return _mapper.Map<ModuloNotificacionDto>(modulo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloNotificacionDto>> Post(ModuloNotificacionDto moduloNotificacionDto){
        var modulo = _mapper.Map<ModuloNotificacion>(moduloNotificacionDto);
        _unitOfWork.ModuloNotificaciones.Add(modulo);
        await _unitOfWork.SaveAsync();
        if(modulo == null){
            return BadRequest();
        }
        moduloNotificacionDto.Id = modulo.Id;
        return CreatedAtAction(nameof(Post), new {id = moduloNotificacionDto.Id}, moduloNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionDto>> Put(int id, [FromBody]ModuloNotificacionDto moduloNotificacionDto){
        if(moduloNotificacionDto.Id == 0){
            moduloNotificacionDto.Id = id;
        }

        if(moduloNotificacionDto.Id != id){
            return BadRequest();
        }

        if(moduloNotificacionDto == null){
            return NotFound();
        }
        var modulo = _mapper.Map<ModuloNotificacion>(moduloNotificacionDto);
        _unitOfWork.ModuloNotificaciones.Update(modulo);
        await _unitOfWork.SaveAsync();
        return moduloNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var modulo = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);
        if(modulo == null){
            return NotFound();
        }
        _unitOfWork.ModuloNotificaciones.Remove(modulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}