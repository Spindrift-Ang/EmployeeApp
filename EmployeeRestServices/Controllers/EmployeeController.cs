using System.Collections.Generic;
using EFEmployeeAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EFEmployeeAccessLibrary.DataAccess;

namespace EmployeeRestServices.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context) => _context = context;
        

  

        // GET: api/Employee/All
        [HttpGet("api/Employee/All")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return _context.Employees;
           
        }

        //GET:  api/Employee/s
        [HttpGet("api/Employee/{id}")]
        public ActionResult<Employee> GetEmployee(string id)
        {
            Guid idUnique;
            if(Guid.TryParse(id, out idUnique))
            {

                var item = _context.Employees.Where(en => en.Id == idUnique).FirstOrDefault();
                if (item == null)
                    return NotFound();
                else
                    return item;
            }
            else
                return NotFound();


        }


        //POST: api/Employee
        [HttpPost("api/Employee")]
        public ActionResult<Employee> PostEmployeeItem(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction("GetEmployee", new Employee { Id = employee.Id }, employee);
        }

        //PUT; api/Employee/s
        [HttpPut("api/Employee/{id}")]
        public ActionResult PutEmployeeItem(string id, Employee employee)
        {

            Guid idUnique;
            if (Guid.TryParse(id, out idUnique) && idUnique == employee.Id)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return NoContent();
            }
            else
                return BadRequest();
        }

        //DELETE:  not needed
        //PATCH: not needed

    }
}
