using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDOperations.Context;
using CRUDOperations.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IApplicationContext _context;
        public EmployeeController(IApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employee = _context.employee.Where(e=> e.IsActive).ToList();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employeeVM)
        {
            if (ModelState.IsValid)
            {
                employeeVM.CreateDate = System.DateTime.Now;
                _context.employee.Add(employeeVM);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        public IActionResult Edit(int id)
        {
            var employee = GetEmployeeInfoById(id);
            if(employee == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employeeVM)
        {
             
            if (ModelState.IsValid)
            {
                employeeVM.UpdateDate = System.DateTime.Now;
                _context.employee.Update(employeeVM);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        public IActionResult Delete(int id)
        {
            var employee = GetEmployeeInfoById(id);
            employee.IsActive = false;
            _context.employee.Update(employee);
            _context.SaveChanges();                   
             return RedirectToAction(nameof(Index));
        }

        private Employee GetEmployeeInfoById(int Id)
        {
            var employee = _context.employee.FirstOrDefault(e => e.Id == Id);
            return employee;
        }
    }
}
