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
public class TipoNotificacionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoNotificacionDto>>> Get()
    {
        var noti = await _unitOfWork.TipoNotificaciones.GetAllAsync();

        return _mapper.Map<List<TipoNotificacionDto>>(noti);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNotificacionDto>> Get(int id){
        var noti = await _unitOfWork.TipoNotificaciones.GetByIdAsync(id);
        if (noti == null){
            return NotFound();
        }
        return _mapper.Map<TipoNotificacionDto>(noti);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoNotificacionDto>> Post(TipoNotificacionDto tipoNotificacionDto){
        var noti = _mapper.Map<TipoNotificacion>(tipoNotificacionDto);
        _unitOfWork.TipoNotificaciones.Add(noti);
        await _unitOfWork.SaveAsync();
        if(noti == null){
            return BadRequest();
        }
        tipoNotificacionDto.Id = noti.Id;
        return CreatedAtAction(nameof(Post), new {id = tipoNotificacionDto.Id}, tipoNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNotificacionDto>> Put(int id, [FromBody]TipoNotificacionDto tipoNotificacionDto){
        if(tipoNotificacionDto.Id == 0){
            tipoNotificacionDto.Id = id;
        }

        if(tipoNotificacionDto.Id != id){
            return BadRequest();
        }

        if(tipoNotificacionDto == null){
            return NotFound();
        }
        var noti = _mapper.Map<TipoNotificacion>(tipoNotificacionDto);
        _unitOfWork.TipoNotificaciones.Update(noti);
        await _unitOfWork.SaveAsync();
        return tipoNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var noti = await _unitOfWork.TipoNotificaciones.GetByIdAsync(id);
        if(noti == null){
            return NotFound();
        }
        _unitOfWork.TipoNotificaciones.Remove(noti);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}