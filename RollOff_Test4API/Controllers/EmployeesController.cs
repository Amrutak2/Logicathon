using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RollOff_Test4API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollOff_Test4API.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
   
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _context;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetDetails()
        {
            //Get all Employees
            try
            {
                var data = await _context.GetAllEmployeeDetails();
                return Ok(_mapper.Map<List<Models.DTO.GetEmployee>>(data));
            }
            catch (Exception e)
            {
                return BadRequest("Error in Controller" + e);
            }
        }
       [HttpGet]
        [Route("[controller]/{id:int}")]
   
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            //Get Employee by Id
            try
            {
                var result = await _context.GetEmployeeByID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Error in Controller" + e);
            }
        }

        
       [HttpGet]
        [Route("[controller]/{data}")]
        public async Task<IActionResult> GetEmployee([FromRoute] string data)
        {
            //fetch employee
            try 
            { 
            var result = await _context.GetEmployee(data);
            if (result == null)
            {
                return NotFound();
            }
            var resultDTO = _mapper.Map<List<Models.DTO.GetEmployeeByID>>(result);
            return Ok(resultDTO);
            }
            catch (Exception e)
            {
                return BadRequest("Error in Controller" + e);
            }
        }
    }
}
