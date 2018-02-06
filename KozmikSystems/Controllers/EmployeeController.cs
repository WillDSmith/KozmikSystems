using KozmikSystems.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KozmikSystems.Controllers
{
    public class EmployeeController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            
            return _db.Employees.ToList<Employee>();
        }

        public ActionResult AddEdit(int id = 0)
        {
            Employee employee = new Employee();
            if (id != 0)
            {
                
                employee = _db.Employees.Where(x => x.Id == id).FirstOrDefault<Employee>();
                
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult AddEdit(Employee employee)
        {
            try
            {
                if (employee.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(employee.ImageUpload.FileName);
                    string extension = Path.GetExtension(employee.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    employee.ImagePath = "~/Images/" + fileName;
                    employee.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
                }

                if (employee.Id == 0)
                    {
                        employee.DateHired = DateTime.Now;
                        _db.Employees.Add(employee);
                        _db.SaveChanges();
                    }
                    else
                    {
                        
                        _db.Entry(employee).State = EntityState.Modified;
                        _db.SaveChanges();

                    }
                
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                
                    Employee employee = _db.Employees.Where(x => x.Id == id).FirstOrDefault<Employee>();
                    _db.Employees.Remove(employee);
                    _db.SaveChanges();
              
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}