using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal1.Models;

namespace StudentPortal1.DependencyInjection
{
    public interface IStudentLogin
    {
        public List<Models.StudentLogin> GetStudentLogins();
        public Models.StudentLogin GetStudentLogin(int id);
        public int AddStudentLogin(Models.StudentLogin ob);

        public int DeleteStudentLogin(int id);

        public int UpDateStudent(int id, string password);
    }
}
