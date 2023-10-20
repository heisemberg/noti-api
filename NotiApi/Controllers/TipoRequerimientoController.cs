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
public class TipoRequerimientoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoRequerimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>> Get()
    {
        var requerimiento = await _unitOfWork.TipoRequerimientos.GetAllAsync();

        return _mapper.Map<List<TipoRequerimientoDto>>(requerimiento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Get(int id){
        var requerimiento = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);
        if (requerimiento == null){
            return NotFound();
        }
        return _mapper.Map<TipoRequerimientoDto>(requerimiento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoRequerimientoDto>> Post(TipoRequerimientoDto tipoRequerimientoDto){
        var requerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
        _unitOfWork.TipoRequerimientos.Add(requerimiento);
        await _unitOfWork.SaveAsync();
        if(requerimiento == null){
            return BadRequest();
        }
        tipoRequerimientoDto.Id = requerimiento.Id;
        return CreatedAtAction(nameof(Post), new {id = tipoRequerimientoDto.Id}, tipoRequerimientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody]TipoRequerimientoDto tipoRequerimientoDto){
        if(tipoRequerimientoDto.Id == 0){
            tipoRequerimientoDto.Id = id;
        }

        if(tipoRequerimientoDto.Id != id){
            return BadRequest();
        }

        if(tipoRequerimientoDto == null){
            return NotFound();
        }
        var requerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
        _unitOfWork.TipoRequerimientos.Update(requerimiento);
        await _unitOfWork.SaveAsync();
        return tipoRequerimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var requerimiento = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);
        if(requerimiento == null){
            return NotFound();
        }
        _unitOfWork.TipoRequerimientos.Remove(requerimiento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}