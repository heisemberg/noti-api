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
public class MaestroVsSubModuloController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MaestroVsSubModuloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MaestroVsSubmoduloDto>>> Get()
    {
        var maestro = await _unitOfWork.MaestrosVsSubModulos.GetAllAsync();

        return _mapper.Map<List<MaestroVsSubmoduloDto>>(maestro);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestroVsSubmoduloDto>> Get(int id){
        var maestro = await _unitOfWork.MaestrosVsSubModulos.GetByIdAsync(id);
        if (maestro == null){
            return NotFound();
        }
        return _mapper.Map<MaestroVsSubmoduloDto>(maestro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestroVsSubmoduloDto>> Post(MaestroVsSubmoduloDto MaestroVsSubmoduloDto){
        var maestro = _mapper.Map<MaestroVsSubmodulo>(MaestroVsSubmoduloDto);
        _unitOfWork.MaestrosVsSubModulos.Add(maestro);
        await _unitOfWork.SaveAsync();
        if(maestro == null){
            return BadRequest();
        }
        MaestroVsSubmoduloDto.Id = maestro.Id;
        return CreatedAtAction(nameof(Post), new {id = MaestroVsSubmoduloDto.Id}, MaestroVsSubmoduloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestroVsSubmoduloDto>> Put(int id, [FromBody]MaestroVsSubmoduloDto MaestroVsSubmoduloDto){
        if(MaestroVsSubmoduloDto.Id == 0){
            MaestroVsSubmoduloDto.Id = id;
        }

        if(MaestroVsSubmoduloDto.Id != id){
            return BadRequest();
        }

        if(MaestroVsSubmoduloDto == null){
            return NotFound();
        }
        var maestro = _mapper.Map<MaestroVsSubmodulo>(MaestroVsSubmoduloDto);
        _unitOfWork.MaestrosVsSubModulos.Update(maestro);
        await _unitOfWork.SaveAsync();
        return MaestroVsSubmoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var maestro = await _unitOfWork.MaestrosVsSubModulos.GetByIdAsync(id);
        if(maestro == null){
            return NotFound();
        }
        _unitOfWork.MaestrosVsSubModulos.Remove(maestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}