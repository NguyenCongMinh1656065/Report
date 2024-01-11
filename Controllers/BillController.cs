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
    public class BillController : ControllerBase
    {
        private IBillRepository _billRepository;
        private IMapper _mapper;

        public BillController(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBills()
        {
            var bills = _mapper.Map<List<BillDto>>(_billRepository.GetBills());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(bills);
        }
        [HttpPost]
        public IActionResult CreatedBills([FromQuery] int ownerId, [FromQuery] int statusId, [FromBody] BillDto billCreate)
        {
            if (billCreate == null)
                return BadRequest(ModelState);
            var bills = _billRepository.GetBills().Where(b => b.Name.Trim().ToUpper() == billCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (bills != null)
            {
                ModelState.AddModelError("", "Bill already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var billMap = _mapper.Map<Bill>(billCreate);
            if (!_billRepository.CreateBill(ownerId , statusId , billMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
