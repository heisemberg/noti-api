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
public class RolVsMaestroController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolVsMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolVsMaestroDto>>> Get()
    {
        var rol = await _unitOfWork.RolesVsMaestros.GetAllAsync();

        return _mapper.Map<List<RolVsMaestroDto>>(rol);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolVsMaestroDto>> Get(int id){
        var rol = await _unitOfWork.RolesVsMaestros.GetByIdAsync(id);
        if (rol == null){
            return NotFound();
        }
        return _mapper.Map<RolVsMaestroDto>(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolVsMaestroDto>> Post(RolVsMaestroDto RolVsMaestroDto){
        var rol = _mapper.Map<RolVsMaestro>(RolVsMaestroDto);
        _unitOfWork.RolesVsMaestros.Add(rol);
        await _unitOfWork.SaveAsync();
        if(rol == null){
            return BadRequest();
        }
        RolVsMaestroDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new {id = RolVsMaestroDto.Id}, RolVsMaestroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolVsMaestroDto>> Put(int id, [FromBody]RolVsMaestroDto RolVsMaestroDto){
        if(RolVsMaestroDto.Id == 0){
            RolVsMaestroDto.Id = id;
        }

        if(RolVsMaestroDto.Id != id){
            return BadRequest();
        }

        if(RolVsMaestroDto == null){
            return NotFound();
        }
        var rol = _mapper.Map<RolVsMaestro>(RolVsMaestroDto);
        _unitOfWork.RolesVsMaestros.Update(rol);
        await _unitOfWork.SaveAsync();
        return RolVsMaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var rol = await _unitOfWork.RolesVsMaestros.GetByIdAsync(id);
        if(rol == null){
            return NotFound();
        }
        _unitOfWork.RolesVsMaestros.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}