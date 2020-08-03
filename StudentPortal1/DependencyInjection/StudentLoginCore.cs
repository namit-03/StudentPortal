using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal1.DependencyInjection;
using StudentPortal1.Models;

namespace StudentPortal1.DependencyInjection
{
    public class StudentLoginCore : IStudentLogin
    {
        Project_1Context db;

         public StudentLoginCore(Project_1Context _db) 
        {
            db=_db;
        }
        public StudentLoginCore()
        {

        }
        public int AddStudentLogin(StudentLogin data)
        {
            if (db != null)
            {
                db.StudentLogin.Add(data);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int DeleteStudentLogin(int id)
        {
           int result = 0;

            if (db != null)
            {

                var post = db.StudentLogin.FirstOrDefault(x => x.Rollno == id);

                if (post != null)
                {

                    db.StudentLogin.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public StudentLogin getStudentLogin(int id)
        {
            if (db != null)
            {
                return (db.StudentLogin.Where(x => x.Rollno == id)).FirstOrDefault();
            }
            return null;
        }

        public List<StudentLogin> GetStudentLogins()
        {
            if (db != null)
            {
                return db.StudentLogin.ToList();
            }
            return null;
        }
    
        public int UpDateStudent(int rollno, string password)
        {

            if (db != null)
            {
            StudentLogin val = db.StudentLogin.Where(x => x.Rollno == rollno).FirstOrDefault();

                if (val != null)
                {
                    db.StudentLogin.Remove(val);
                    db.SaveChanges();
                    if ((rollno != 0))
                        val.Rollno= rollno;
                    if ((password!= ""))
                        val.Password = password;
                    db.StudentLogin.Add(val);
                    db.SaveChanges();
                    return 1;
                }

            }
            return -1;
        }

        public StudentLogin GetStudentLogin(int id)
        {
            throw new NotImplementedException();
        }
    }
}
