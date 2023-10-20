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
public class FormatoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FormatoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FormatoDto>>> Get()
    {
        var formato = await _unitOfWork.Formatos.GetAllAsync();

        return _mapper.Map<List<FormatoDto>>(formato);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormatoDto>> Get(int id){
        var formato = await _unitOfWork.Formatos.GetByIdAsync(id);
        if (formato == null){
            return NotFound();
        }
        return _mapper.Map<FormatoDto>(formato);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FormatoDto>> Post(FormatoDto formatoDto){
        var formato = _mapper.Map<Formato>(formatoDto);
        _unitOfWork.Formatos.Add(formato);
        await _unitOfWork.SaveAsync();
        if(formato == null){
            return BadRequest();
        }
        formatoDto.Id = formato.Id;
        return CreatedAtAction(nameof(Post), new {id = formatoDto.Id}, formatoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormatoDto>> Put(int id, [FromBody]FormatoDto FormatoDto){
        if(FormatoDto.Id == 0){
            FormatoDto.Id = id;
        }

        if(FormatoDto.Id != id){
            return BadRequest();
        }

        if(FormatoDto == null){
            return NotFound();
        }
        var formato = _mapper.Map<Formato>(FormatoDto);
        _unitOfWork.Formatos.Update(formato);
        await _unitOfWork.SaveAsync();
        return FormatoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var formato = await _unitOfWork.Formatos.GetByIdAsync(id);
        if(formato == null){
            return NotFound();
        }
        _unitOfWork.Formatos.Remove(formato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}