using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Services;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

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

        // GET: api/Palettes/GetAllPublic
        [HttpGet("GetAllPublic")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PaletteReadOnlyDto>>> GetPublicPalettes()
        {
            _logger.LogInformation($"Request to {nameof(GetPublicPalettes)}");
            var paletteDtos = await _palettesRepository.PublicGetAllAsync();
            return Ok(paletteDtos);
        }

        // GET: api/Palettes/GetAllPublicPaged/?StartIndex=0&pageSize=15&PageNumber=1
        [HttpGet("GetAllPublicPaged")]
        public async Task<ActionResult<PagedData<PaletteReadOnlyDto>>> GetPublicPagedPalettes([FromQuery] PagingParameters pagingParameters)
        {
            _logger.LogInformation($"Request to {nameof(GetPublicPagedPalettes)}");
            var pagedPalettes = await _palettesRepository.PublicGetAllPagedAsync(pagingParameters);
            return Ok(pagedPalettes);
        }

        // GET: api/Palettes/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PaletteReadOnlyDto>>> GetPalettes()
        {
            _logger.LogInformation($"Request to {nameof(GetPalettes)}");
            var paletteDtos = await _palettesRepository.GetAllIncludeColoursAsync();
            return Ok(paletteDtos);
        }

        // GET: api/Palettes/GetAllPaged/?StartIndex=0&pageSize=15&PageNumber=1
        [HttpGet("GetAllPaged")]
        public async Task<ActionResult<PagedData<PaletteReadOnlyDto>>> GetPagedPalettes([FromQuery] PagingParameters pagingParameters)
        {
            _logger.LogInformation($"Request to {nameof(GetPagedPalettes)}");
            var pagedPalettes = await _palettesRepository.GetAllPagedIncludeColoursAsync(pagingParameters);
            return Ok(pagedPalettes);
        }

        // GET: api/Palettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaletteReadOnlyDto>> GetPalette(int id)
        {
            _logger.LogInformation($"Request to {nameof(GetPalette)}");
            var paletteDto = await _palettesRepository.GetIncludeColoursAsync(id);
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
                    await NewColour(new ColourDto { HexCode = colour });
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
            _logger.LogInformation($"Colours:");
            foreach (var colour in paletteColours)
            {
                _logger.LogInformation($"{colour}");
            }
            

            foreach (string colour in paletteColours)
            {
                await NewColour(new ColourDto { HexCode = colour });
            }

            var palette = await _palettesRepository.CreateAsync(paletteDto);

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

        private async Task NewColour(ColourDto colour)
        {
            _logger.LogInformation($"Creating New Colour: {colour.HexCode.ToUpper()}");
            if (await _coloursRepository.Exists(colour.HexCode.ToUpper()) == false) // create new colour record if it does not exist
            {
                await _coloursRepository.CreateNormalizedAsync(colour);
                _logger.LogInformation($"Succesfully Created New Colour: {colour.HexCode.ToUpper()}");
            }
            else
            {
                _logger.LogInformation($"Colour Already Exists: {colour.HexCode.ToUpper()}");
            }
        }
    }
}