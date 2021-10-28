using dotnetApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetApp.Models;
using dotnetApp.Service;

namespace dotnetApp.Controllers
{
    
    public class StudentsController : Controller
    {
        // GET: StudentsController
        private readonly StudentsDbContext _context;
        private readonly AutoGenerateStudentIdService _autogen;
        public StudentsController(StudentsDbContext context, AutoGenerateStudentIdService autogen)
        {
            _context = context;
            _autogen = autogen;
        }
        public IActionResult Index()
        {
            var students=  _context.Estudyante.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult SaveOrEdit(int studentId)
        {
            ViewBag.PageName = studentId == 0 ? "Create Student" : "Edit Student";
            ViewBag.IsEdit = studentId == 0 ? false : true;
            if (studentId == 0)
            {
                return View();
            }
            else
            {
                var students =  _context.Estudyante.Find(studentId);

                if (students == null)
                {
                    return NotFound();
                }
                return View(students);
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveOrEdit(int studentId, [Bind("StudentsId,Name,Section,Address,EnrolledDate")]
        Students studentsData)
        {
            bool IsStudentExist = false;

            //int rawData = _autogen.getStudentId();

            Students students = _context.Estudyante.Find(studentId);

            if (students != null)
            {
                IsStudentExist = true;
            }
            else
            {
                students = new Students();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SaveChangesService saveUpdate = new SaveChangesService();
                    saveUpdate.SaveUpdate(students, studentsData, _context, IsStudentExist);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentsData);
        }
        [HttpGet]
        public IActionResult Details(int studentId)
        {
            if (studentId == 0)
            {
                return NotFound();
            }
            var students =  _context.Estudyante.FirstOrDefault(m => m.StudentId == studentId);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Delete(int? studentId)
        {
            if (studentId == 0)
            {
                return NotFound();
            }
            var student = _context.Estudyante.FirstOrDefault(m => m.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int studentId)
        {
            var student = _context.Estudyante.Find(studentId);
            _context.Estudyante.Remove(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
