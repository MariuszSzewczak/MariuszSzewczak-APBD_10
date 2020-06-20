using System.Collections;
using Cw10.DTOs.Requests;
using Cw10.Models;

namespace Cw10.Services
{
    public interface IStudentDbService
    {
        public IEnumerable GetStudents();
        public Student ModifyStudent(ModifyStudentRequest request);
        public Student DeleteStudent(DeleteStudentRequest request);
        
        Enrollment EnrollStudent(EnrollStudentRequest request);
        Enrollment PromoteStudent(PromoteStudentRequest request);
    }
}