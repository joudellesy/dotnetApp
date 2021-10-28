using dotnetApp.Data;
using dotnetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetApp.Service
{
    public class SaveChangesService
    {

        public void SaveUpdate(Students students, Students studentsData, StudentsDbContext _context, bool IsStudentExist) 
        {

            students.Name = studentsData.Name;
            students.Section = studentsData.Section;
            students.Address = studentsData.Address;
            students.EnrolledDate = studentsData.EnrolledDate;
            students.DateCreated = DateTime.Now;

            if (IsStudentExist)
            {
                _context.Update(students);
            }
            else
            {
                _context.Add(students);
            }
            _context.SaveChanges();

        }
    }
}
