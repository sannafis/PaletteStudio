﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Services;
using PaletteStudioApi.Data;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;
using PaletteStudioApi.Static;
using System.Security.Claims;

namespace PaletteStudioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PalettesController : ControllerBase
    {
        private readonly ILogger<PalettesController> _logger;
        private readonly IPalettesRepository _palettesRepository;
        private readonly IColoursRepository _coloursRepository;

        public PalettesController(ILogger<PalettesController> logger, IPalettesRepository palettesRepository, IColoursRepository coloursRepository)
        {
            this._logger = logger;
            this._palettesRepository = palettesRepository;
            this._coloursRepository = coloursRepository;
        }

        // GET: api/Palettes/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PaletteReadOnlyDto>>> GetPalettes()
        {
            _logger.LogInformation($"Request to {nameof(GetPalettes)}");
            var paletteDtos = await _palettesRepository.GetAllIncludeColours();
            return Ok(paletteDtos);
        }

        // GET: api/Palettes/?StartIndex=0&pageSize=15&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedData<PaletteReadOnlyDto>>> GetPagedPalettes([FromQuery] PagingParameters pagingParameters)
        {
            _logger.LogInformation($"Request to {nameof(GetPagedPalettes)}");
            var pagedPalettes = await _palettesRepository.GetAllPagedIncludeColours(pagingParameters);
            return Ok(pagedPalettes);
        }

        // GET: api/Palettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaletteReadOnlyDto>> GetPalette(int id)
        {
            string userId = HttpContext.User.FindFirstValue("uid");

            if (userId == null)
            {
                throw new UnauthorizedException(nameof(GetPalette), "(User not found)");
            }

            _logger.LogInformation($"Request to {nameof(GetPalette)}");
            var paletteDto = await _palettesRepository.GetIncludeColours(id, userId);
            return Ok(paletteDto);
        }

        // PUT: api/Palettes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPalette(int id, PaletteUpdateDto paletteDto)
        {
            _logger.LogInformation($"Request to {nameof(PutPalette)}");

            if (id != paletteDto.Id)
            {
                throw new BadRequestException(nameof(PutPalette), id);
            }

            try
            {
                // get colours in palette
                var paletteColours = paletteDto.ColourGroups
                    .SelectMany(p => p.ForegroundColours
                        .Select(f => f.ColourHexCode)
                        .Prepend(p.BackgroundColourHexCode))
                    .ToList();

                foreach (string colour in paletteColours)
                {
                    if (!await _coloursRepository.Exists(colour)) // check if colour exists, if not, create a new colour record
                    {
                        ColourDto newColourDto = new ColourDto { HexCode = colour };
                        await _coloursRepository.CreateNormalizedAsync(newColourDto);
                    }
                }

                await _palettesRepository.UpdateFullAsync(id, paletteDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _palettesRepository.Exists(id))
                {
                    throw new NotFoundException(nameof(PutPalette), id);
                }
                else
                {
                    throw; // Throw exception to be handled
                }
            }
            return NoContent();
        }

        // POST: api/Palettes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaletteReadOnlyDto>> PostPalette(PaletteCreateDto paletteDto)
        {
            _logger.LogInformation($"Request to {nameof(PostPalette)}");

            var paletteColours = paletteDto.ColourGroups
                .SelectMany(p => p.ForegroundColours
                    .Select(f => f.ColourHexCode)
                    .Prepend(p.BackgroundColourHexCode))
                .ToList();

            foreach (string colour in paletteColours)
            {
                if (!await _coloursRepository.Exists(colour)) // create new colour record if it does not exist
                {
                    ColourDto newColourDto = new ColourDto { HexCode = colour };
                    await _coloursRepository.CreateNormalizedAsync(newColourDto);
                }
            }

            var palette = await _palettesRepository.CreateAsync<PaletteCreateDto, PaletteReadOnlyDto>(paletteDto);

            return CreatedAtAction(nameof(GetPalette), new { id = palette.Id }, palette);
        }

        // DELETE: api/Palettes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePalette(int id)
        {
            _logger.LogInformation($"Request to {nameof(DeletePalette)} for Id {id}");
            await _palettesRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}