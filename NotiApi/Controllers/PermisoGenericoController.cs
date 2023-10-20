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
public class PermisoGenericoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PermisoGenericoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PermisoGenericoDto>>> Get()
    {
        var permiso = await _unitOfWork.PermisosGenericos.GetAllAsync();

        return _mapper.Map<List<PermisoGenericoDto>>(permiso);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisoGenericoDto>> Get(int id){
        var permiso = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permiso == null){
            return NotFound();
        }
        return _mapper.Map<PermisoGenericoDto>(permiso);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisoGenericoDto>> Post(PermisoGenericoDto PermisoGenericoDto){
        var permiso = _mapper.Map<PermisoGenerico>(PermisoGenericoDto);
        _unitOfWork.PermisosGenericos.Add(permiso);
        await _unitOfWork.SaveAsync();
        if(permiso == null){
            return BadRequest();
        }
        PermisoGenericoDto.Id = permiso.Id;
        return CreatedAtAction(nameof(Post), new {id = PermisoGenericoDto.Id}, PermisoGenericoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisoGenericoDto>> Put(int id, [FromBody]PermisoGenericoDto PermisoGenericoDto){
        if(PermisoGenericoDto.Id == 0){
            PermisoGenericoDto.Id = id;
        }

        if(PermisoGenericoDto.Id != id){
            return BadRequest();
        }

        if(PermisoGenericoDto == null){
            return NotFound();
        }
        var permiso = _mapper.Map<PermisoGenerico>(PermisoGenericoDto);
        _unitOfWork.PermisosGenericos.Update(permiso);
        await _unitOfWork.SaveAsync();
        return PermisoGenericoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var permiso = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if(permiso == null){
            return NotFound();
        }
        _unitOfWork.PermisosGenericos.Remove(permiso);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}