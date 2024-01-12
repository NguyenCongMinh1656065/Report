using AutoMapper;
using Hello_World.Dto;
using Hello_World.Interface;
using Hello_World.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello_World.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerRepository _ownerRepository;
        private IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository , IMapper mapper) 
        { 
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOwners() 
        {
            List<OwnerDto> owners = null;
            try
            {
                owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(owners);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        public IActionResult CreateOwner([FromBody] OwnerDto ownerCreate )
        {
            if ( ownerCreate == null )
                
            return BadRequest(ModelState);
            var owner = _ownerRepository.GetOwners().Where(c => c.Name.Trim().ToUpper() == ownerCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();
            if (owner != null )
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var ownerMap = _mapper.Map<Owner>(ownerCreate);
            if (!_ownerRepository.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
