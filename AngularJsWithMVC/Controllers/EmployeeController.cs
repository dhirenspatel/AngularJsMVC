using AngularJsWithMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJsWithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult GetEmployees()
        {
            using (EmployeeDbContext Obj = new EmployeeDbContext())
            {
                List<Employee> Emp = Obj.EmployeeDB.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string Add(Employee Employe)
        {
            if (Employe != null)
            {
                using (EmployeeDbContext Obj = new EmployeeDbContext())
                {
                    Obj.EmployeeDB.Add(Employe);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }

        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult GetEmployeeById(string Id)
        {
            using (EmployeeDbContext Obj = new EmployeeDbContext())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.EmployeeDB.Find(Id), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Update(Employee Emp)
        {
            if (Emp != null)
            {
                using (EmployeeDbContext Obj = new EmployeeDbContext())
                {
                    var Emp_ = Obj.Entry(Emp);
                    Employee EmpObj = Obj.EmployeeDB.Where(x => x.Id == Emp.Id).FirstOrDefault();
                    EmpObj.Age = Emp.Age;
                    EmpObj.City = Emp.City;
                    EmpObj.Name = Emp.Name;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Delete(Employee Emp)
        {
            if (Emp != null)
            {
                using (EmployeeDbContext Obj = new EmployeeDbContext())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.EmployeeDB.Attach(Emp);
                        Obj.EmployeeDB.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
    }
}