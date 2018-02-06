using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KozmikSystems.Models;

namespace KozmikSystems.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/EmployeeAPI
        public IQueryable<Employee> GetEmployees()
        {
            return _db.Employees;
        }

        // GET: api/EmployeeAPI/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/EmployeeAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _db.Entry(employee).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeeAPI
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            employee.DateHired = DateTime.Now;

            _db.Employees.Add(employee);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/EmployeeAPI/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(employee);
            _db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return _db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}