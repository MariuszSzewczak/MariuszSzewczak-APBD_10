using System;
using System.Collections;
using System.Linq;
using Cw10.DTOs.Requests;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services
{
    public class SqlStudentDbService: IStudentDbService
    {
        public _2019SBDContext _context { get; set; }

        public SqlStudentDbService(_2019SBDContext context)
        {
            _context = context;
        }
        
        
        public IEnumerable GetStudents()
        {
            var list = _context.Student.ToList();
            return list;
        }

        public Student ModifyStudent(ModifyStudentRequest request)
        {
            var student = _context.Student.FirstOrDefault(e => e.IndexNumber == request.IndexNumber);
                
            if(student==null)
                throw new Exception("Nie ma takiego studenta");

            student.IndexNumber = request.IndexNumber;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.BirthDate = request.BirthDate;
            student.IdEnrollment = request.IdEnrollment;

            _context.SaveChanges();

            return student;
        }

        public Student DeleteStudent(DeleteStudentRequest request)
        {
            var student = _context.Student.FirstOrDefault(s => s.IndexNumber == request.IndexNumber);
                
            if(student==null)
                throw new Exception("Nie ma takiego studenta");
                
            _context.Remove(student);
            _context.SaveChanges();

            return student;
        }
        

        public Enrollment EnrollStudent(EnrollStudentRequest request)
        {
            var studies = _context.Studies.FirstOrDefault(s => s.Name == request.StudiesName);
            
            if (studies == null) 
                throw new Exception("Takie studia nie istnieja");
            

            var enrollment = _context.Enrollment.Where(e => e.IdStudy==studies.IdStudy && e.Semester==1)
                .OrderByDescending(e => e.StartDate).FirstOrDefault();

            if (enrollment == null)
            {
                enrollment= new Enrollment()
                {
                    IdEnrollment = _context.Enrollment.Max(e=> e.IdEnrollment)+1,
                    Semester = 1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.Now
                };
                _context.Enrollment.Add(enrollment);
            }

            var czyStudentIstnieje = _context.Student.FirstOrDefault(e => e.IndexNumber == request.IndexNumber);
            
            if (czyStudentIstnieje != null)
                throw new Exception("Taki student juz istnieje!");
            
            
            var student = new Student()
            {
                IndexNumber = request.IndexNumber,
                BirthDate = Convert.ToDateTime(request.BirthDate),
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdEnrollment = enrollment.IdEnrollment
            };
            
            _context.Student.Add(student);
            _context.SaveChanges();
            return enrollment;

        }

        public Enrollment PromoteStudent(PromoteStudentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}