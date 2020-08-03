using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal1.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal1.DependencyInjection
{

    public class TeacherLoginCore : ITeacherLogin
    {


        Project_1Context db;

       public TeacherLoginCore(Project_1Context _db)
        {
            db = _db;
        }
        public TeacherLoginCore()
        {
           
        }

        public List<Models.TeacherLogin> GetTeacherLogins()
        {
            if (db != null)
            {
                return db.TeacherLogin.ToList();
            }
            return null;     
          }

        public int AddTeacherLogin(Models.TeacherLogin data)
        {
            if (db != null)
            {
                db.TeacherLogin.Add(data);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int DeleteTeacherLogin(int id)
        {

            int result = 0;

            if (db != null)
            {

                var post = db.TeacherLogin.FirstOrDefault(x => x.TeacherId == id);

                if (post != null)
                {

                    db.TeacherLogin.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public TeacherLogin GetTeacherLogin(int id)
        {
            if (db != null)
            {
             return (db.TeacherLogin.Where(x => x.TeacherId == id)).FirstOrDefault();
             
             }
            else
            {
                return null;
            }
            
        }

        public int UpDateTeacher(int id, string password)
        {
            if (db != null)
            {
              var val = db.TeacherLogin.Where(x => x.TeacherId == id).FirstOrDefault();
               
                if (val != null)
                {
                    db.TeacherLogin.Remove(val);
                    db.SaveChanges();
                    if ((id != 0))
                       val.TeacherId = id;
                    if ((password != ""))
                        val.Password = password;
                    db.TeacherLogin.Add(val);
                    db.SaveChanges();
                    return 1;
                }
                
            }
            return -1;
        }

        TeacherLogin ITeacherLogin.GetTeacherLogin(int id)
        {
            throw new NotImplementedException();
        }
    }
}
