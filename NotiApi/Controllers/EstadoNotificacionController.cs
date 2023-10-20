using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotiApi.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoti.Controllers;

public class EstadoNotificacionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EstadoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EstadoNotificacionDto>>> Get()
    {
        var estado = await _unitOfWork.EstadosNotificaciones.GetAllAsync();

        return _mapper.Map<List<EstadoNotificacionDto>>(estado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoNotificacionDto>> Get(int id){
        var estado = await _unitOfWork.EstadosNotificaciones.GetByIdAsync(id);
        if (estado == null){
            return NotFound();
        }
        return _mapper.Map<EstadoNotificacionDto>(estado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EstadoNotificacionDto>> Post(EstadoNotificacionDto estadoNotificacionDto){
        var estado = _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);
        _unitOfWork.EstadosNotificaciones.Add(estado);
        await _unitOfWork.SaveAsync();
        if(estado == null){
            return BadRequest();
        }
        estadoNotificacionDto.Id = estado.Id;
        return CreatedAtAction(nameof(Post), new {id = estadoNotificacionDto.Id}, estadoNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoNotificacionDto>> Put(int id, [FromBody]EstadoNotificacionDto estadoNotificacionDto){
        if(estadoNotificacionDto.Id == 0){
            estadoNotificacionDto.Id = id;
        }

        if(estadoNotificacionDto.Id != id){
            return BadRequest();
        }

        if(estadoNotificacionDto == null){
            return NotFound();
        }
        var estado = _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);
        _unitOfWork.EstadosNotificaciones.Update(estado);
        await _unitOfWork.SaveAsync();
        return estadoNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var estado = await _unitOfWork.EstadosNotificaciones.GetByIdAsync(id);
        if(estado == null){
            return NotFound();
        }
        _unitOfWork.EstadosNotificaciones.Remove(estado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}