using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers
{
    //Pega a rota e mapear sempre para api barra nome do controller  que neste caso é o controller Employee
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpGet]
        [Route("/employees")]//configuaração manual da rota para employee
        public async Task<ActionResult> GetEmployees()
        {
            return Ok(await _employeeContext.Employees.ToListAsync());
        }

        [HttpPost]
        [Route("/employees")]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            await _employeeContext.Employees.AddAsync(employee);

            await _employeeContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]//actualizar
        [Route("/employees")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            //validação caso não encontre o elemento na base de dados
            var dbEmployee = await _employeeContext.Employees.FindAsync(employee.Id);

            if (dbEmployee == null) return NotFound();

            dbEmployee.Name = employee.Name;
            dbEmployee.Age = employee.Age;
            dbEmployee.Photo = employee.Photo;

            await _employeeContext.SaveChangesAsync();

            return Ok(employee);
         
        }

        [HttpDelete]
        [Route("/employees")]
        public async Task<ActionResult> DeleteEmploye(int id)
        {
            var dbEmployee = await _employeeContext.Employees.FindAsync(id);

            if(dbEmployee == null) return NotFound();

            _employeeContext.Employees.Remove(dbEmployee);

            await _employeeContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
