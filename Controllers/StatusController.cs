using AutoMapper;
using Hello_World.Dto;
using Hello_World.Interface;
using Hello_World.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace Hello_World.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusRepository _statusRepository;
        private IMapper _mapper;

        public StatusController(IStatusRepository statusRepository, IMapper mapper) 
        { 
            _statusRepository = statusRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetStatuses()
        {
            /*
            var statuses = _mapper.Map<List<StatusDto>>(_statusRepository.GetStatuses());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(statuses);
            */
            var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(45) };
            List<StatusDto> statuses = null;

            try
            {
                statuses = _mapper.Map<List<StatusDto>>(_statusRepository.GetStatuses());

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(statuses);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây, có thể log, thông báo, hoặc thực hiện các hành động cần thiết.
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
        [HttpGet]
        public IActionResult GetBillByStatusId(int statusId)
        {
            //var bills = _mapper.Map<List<BillDto>>(_statusRepository.GetBillByStatus(statusId));
            //if (!ModelState.IsValid)
            //{
            //return BadRequest();
            //}
            //return Ok(bills);
            var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(45) };
            var circuitBreakerPolicy = Policy
            .Handle<Exception>()
            .CircuitBreaker(3, TimeSpan.FromSeconds(30));
            List<BillDto> bills = null;

            try
            {
                bills = _mapper.Map<List<BillDto>>(_statusRepository.GetBillByStatus(statusId));

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                return Ok(bills);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
        [HttpPost]
        public IActionResult CreateStatus([FromBody] StatusDto createStatus)
        {
            var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(45) };
            if (createStatus == null)
            {
                return BadRequest(ModelState);
            }
            var status = _statusRepository.GetStatuses().Where(s => s.Name.Trim().ToUpper() == createStatus.Name.ToUpper()).FirstOrDefault();
            if (status != null)
            {
                ModelState.AddModelError("", "Status already exists");
                return StatusCode(422, ModelState);
            }
            if ( !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var statusMap = _mapper.Map<Status>(createStatus);
            if (!_statusRepository.CreateStatus(statusMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }   
            return Ok();
        }
        
    }
}
