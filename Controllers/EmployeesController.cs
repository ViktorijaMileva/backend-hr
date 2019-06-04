using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Hr_management_system.Models;
using Hr_management_system.Repository;
using Hr_management_system.Services;

namespace Hr_management_system.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        #region Database init 
        private hr_databaseContext db = new hr_databaseContext();

        #endregion
        public EmployeesController(hr_databaseContext context)
        {
            this.db = context;
        }

        // api/employees/all
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Employees> GetEmployees()
        {
            var employees = db.Employees;

          
            // Response.Headers.Add("A")
            // Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            // Response.Headers.Add("Access-Control-Allow-Origin", "*");
            // Response.Headers.Add("Access-Control-Allow-Methods" , "GET, POST, PUT, DELETE, OPTIONS");

            return employees;
        }

        // api/employees/employee/{embg}
        [HttpGet("{id}")]
        [ActionName("employee")]
        public async Task<IActionResult> GetEmployees([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ob = await db.Employees.FindAsync(id);

            if (ob == null)
            {
                return NotFound();
            }

         
            return Ok(ob);      //employee
        }

        // api/employees/employee/info/{embg}
        [HttpGet("info/{embg}")]
        [ActionName("employee")]
        public async Task<IActionResult> GetEmployeesInfo([FromRoute] string embg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empInfo = await db.EmployeeInfo.Where(x => x.Embg == embg).FirstOrDefaultAsync();

            if (empInfo == null)
            {
                return NotFound();
            }

         
            return Ok(empInfo);
        }

        #region CRUD

        // api/employees/create
        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            // db.EmployeeInfo.Add(empInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EmployeesExist(employee.Embg))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                // else if(EmployeeInfoExist(empInfo.Embg))
                // {
                //     return new StatusCodeResult(StatusCodes.Status409Conflict);
                // }
                else
                {
                    ex.GetBaseException();
                }
            }


            return CreatedAtAction("create", new { id = employee.Embg }, employee);
        }

        // api/employees/create/info
        [HttpPost("info")]
        [ActionName("create")]
        public async Task<IActionResult> CreateEmployeesInfo([FromBody] EmployeeInfo empInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (EmployeeInfoExist(empInfo.Embg))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                db.EmployeeInfo.Add(empInfo);
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.GetBaseException();
            }
            catch (DbUpdateException ex)
            {
                ex.GetBaseException();
            }

           
            return CreatedAtAction("create", empInfo);
        }

        // api/employees/update/id
        [HttpPost("{id}")]
        [ActionName("update")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] string id, [FromBody] Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EmployeesExist(id))
            {
                return NotFound();
            }

            if (id != employee.Embg)
            {
                return BadRequest();
            }


            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.GetBaseException();
            }

           
            return Ok(employee);
        }

        // api/employees/update/info/id
        [HttpPost("info/{id}")]
        [ActionName("update")]
        public async Task<IActionResult> UpdateEmployeesInfo([FromRoute] string id, [FromBody] EmployeeInfo employee)      //TODO
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EmployeesExist(id) || !EmployeeInfoExist(id))
            {
                return NotFound();
            }

            if (id != employee.Embg)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            // db.Update(employee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.GetBaseException();
            }

            Logging.writeToLog("api/employees/update/info/" + id, "POST/Update");

            return Ok(employee);
        }

        // api/employees/delete
        [HttpDelete]
        [HttpPost]
        [ActionName("delete")]
        public async Task<IActionResult> DeleteEmployee([FromBody] string id)      //DONE FromRoute TODO: Cascade delete
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await db.Employees.FindAsync(id);

            var empInfo = db.EmployeeInfo.Where(x => x.Embg == id).FirstOrDefault();

            if (employee == null)
            {
                return NotFound();
            }
            else if (employee != null && empInfo == null)
            {
                try
                {
                    db.Remove(employee);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ex.GetBaseException();
                }
            }
            else if (employee != null && empInfo != null)
            {
                try
                {
                    db.EmployeeInfo.Remove(empInfo);
                    db.Employees.Remove(employee);

                    await db.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ex.GetBaseException();
                }
            }

            Logging.writeToLog("api/employees/delete", "DELETE");

            return Ok("Deleted");
        }

        #endregion
        private bool EmployeesExist(string id)
        {
            return db.Employees.Any(x => x.Embg == id);
        }
        private bool EmployeeInfoExist(string id)
        {
            return db.EmployeeInfo.Any(x => x.Embg == id);
        }
    }
}