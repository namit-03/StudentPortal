using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal1.Models;


namespace StudentPortal1.DependencyInjection
{
    public interface ITeacherLogin
    {
    public List<Models.TeacherLogin> GetTeacherLogins();
      public  Models.TeacherLogin GetTeacherLogin(int id);

        public int UpDateTeacher(int id, string password);
        public  int AddTeacherLogin(Models.TeacherLogin ob);

      public int DeleteTeacherLogin(int id);

        
    } 
}
