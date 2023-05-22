using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaletteStudioApi.Services;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ColoursController : ControllerBase
    {
        private readonly IColoursRepository _coloursRepository;

        public ColoursController(IColoursRepository coloursRepository)
        {
            this._coloursRepository = coloursRepository;
        }

        // GET: api/Colours/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ColourDto>>> GetColours()
        {
            var colourDtos = await _coloursRepository.GetAllAsync();
            return Ok(colourDtos);
        }

        // GET: api/Colours/?StartIndex=0&pageSize=15&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedData<ColourDto>>> GetPagedColours([FromQuery] PagingParameters pagingParameters)
        {
            var pagedColours = await _coloursRepository.GetAllPagedAsync(pagingParameters);
            return Ok(pagedColours);
        }

        // GET: api/Colours/5
        [HttpGet("{hex}")]
        public async Task<ActionResult<ColourDto>> GetColour(string hex)
        {
            var colourDto = await _coloursRepository.GetAsync(hex);
            return Ok(colourDto);
        }
    }
}