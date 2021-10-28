using dotnetApp.Data;
using dotnetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetApp.Service
{
    public class AutoGenerateStudentIdService
    {
        private readonly StudentsDbContext _context;

        public AutoGenerateStudentIdService(StudentsDbContext context)
        {
            _context = context;
        }
        public int getStudentId ()
        {
            int ctr = 01;
            var rawVal = 0;
            string date = DateTime.Now.ToShortDateString();

            var rawID = ctr;

            var students = _context.Estudyante.Where(x => x.StudentId == rawID).OrderBy(x => x.DateCreated).LastOrDefault();

                if (students == null)
                {
                    rawVal = rawID;
                }
                else {
                    rawVal = students.StudentId+1;
                }

            return rawVal;
        }
}
}
