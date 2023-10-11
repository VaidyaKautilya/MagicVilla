using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.VillaNumber;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _villaNumberRepo;
        private readonly IVillaRepository _villaRepo;

        public VillaNumberController(IMapper mapper, IVillaNumberRepository villaNumberRepo , IVillaRepository villaRepo)
        {
            _mapper = mapper;
            _villaNumberRepo = villaNumberRepo;
            _villaRepo = villaRepo;
            this._response = new();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaList = await _villaNumberRepo.GetAllAsync(includeProperties:"Villa");
                _response.Result = _mapper.Map<List<VillaNumberDto>>(villaList);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();
                var villa = await _villaNumberRepo.GetAsync(x => x.VillaNo == id);
                if (villa == null)
                    return NotFound();
                _response.Result = _mapper.Map<VillaNumberDto>(villa);
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(Name = "CreateVillaNumber")]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto createDTO)
        {
            try
            {
                if (await _villaNumberRepo.GetAsync(u => u.VillaNo == createDTO.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessage", "Villa Number is already exists");
                    return BadRequest(ModelState);
                }

                if (await _villaRepo.GetAsync(u => u.Id == createDTO.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessage", "Villa Is In valid");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                    return BadRequest(createDTO);
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDTO);
                await _villaNumberRepo.CreateAsync(villaNumber);
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<VillaNumberCreateDto>(villaNumber);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute(nameof(GetVillaNumber), new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
            
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();
                var villa = await _villaNumberRepo.GetAsync(x => x.VillaNo == id);
                if (villa == null)
                    return NotFound();
                await _villaNumberRepo.RemoveAsync(villa);
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
            
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{Id:int}", Name = "UpdateVillaNumber")]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int Id, [FromBody] VillaNumberUpdateDto UpdateDto)
        {
            try
            {
                if (UpdateDto == null || Id != UpdateDto.VillaNo)
                    return BadRequest();
                if (await _villaRepo.GetAsync(u => u.Id == UpdateDto.VillaId) == null)
                {
                    ModelState.AddModelError("CustomError", "Villa Is In valid");
                    return BadRequest(ModelState);
                }
                VillaNumber model = _mapper.Map<VillaNumber>(UpdateDto);
                await _villaNumberRepo.UpdateAsync(model);
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialVillaNumber")]
        public async Task<IActionResult> UpdatePartialVillaNumber(int id, JsonPatchDocument<VillaNumberUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var villaNumber = await _villaNumberRepo.GetAsync(x => x.VillaNo == id, tracked: false);
            VillaNumberUpdateDto villaDTO = _mapper.Map<VillaNumberUpdateDto>(villaNumber);
            if (villaNumber == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            patchDto.ApplyTo(villaDTO, ModelState);
            VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);
            await _villaNumberRepo.UpdateAsync(model);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return NoContent();
        }
    }
}