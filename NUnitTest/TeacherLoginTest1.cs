using NUnit.Framework;
using Moq;
using StudentPortal1.Models;
using StudentPortal1.DependencyInjection;
using StudentPortal1.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace NUnitTest
{

    
    public class Tests
    {
        Project_1Context db;
        [SetUp]
        public void Setup()
        {
            var Login = new List<StudentPortal1.Models.TeacherLogin>
            {
                new StudentPortal1.Models.TeacherLogin { TeacherId = 1, Password = "abcd" },
                new StudentPortal1.Models.TeacherLogin { TeacherId = 2, Password = "123a" }
            };
            var teacherLoginData = Login.AsQueryable();
            var mockset = new Mock<DbSet<StudentPortal1.Models.TeacherLogin>>();
            mockset.As<IQueryable<StudentPortal1.Models.TeacherLogin>>().Setup(m => m.Provider).Returns(teacherLoginData.Provider);
            mockset.As<IQueryable<StudentPortal1.Models.TeacherLogin>>().Setup(m => m.Expression).Returns(teacherLoginData.Expression);
            mockset.As<IQueryable<StudentPortal1.Models.TeacherLogin>>().Setup(m => m.ElementType).Returns(teacherLoginData.ElementType);
            mockset.As<IQueryable<StudentPortal1.Models.TeacherLogin>>().Setup(m => m.GetEnumerator()).Returns(teacherLoginData.GetEnumerator());

            var mocksetcontext = new Mock<Project_1Context>();
            mocksetcontext.Setup(c => c.TeacherLogin).Returns(mockset.Object);
              db = mocksetcontext.Object;


        }




        [Test]
        public void IsGettingData()
        {
            StudentPortal1.DependencyInjection.TeacherLoginCore teacherLoginData = new StudentPortal1.DependencyInjection.TeacherLoginCore(db);
            TeacherLoginController logob = new TeacherLoginController(teacherLoginData);
            var res = logob.GetTeacherLogin(1);
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);
        }
        [Test]
        public void IsPostingData()
        {

            StudentPortal1.DependencyInjection.TeacherLoginCore teacherLoginData = new StudentPortal1.DependencyInjection.TeacherLoginCore(db);
            TeacherLoginController obj = new TeacherLoginController(teacherLoginData);
            
            var detail = new StudentPortal1.Models.TeacherLogin()
            {
                 TeacherId = 3, Password = "abcd"
            };
           var res= obj.AddDetail(detail);
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);

        }
        [Test]
            public void IsDeletingData()
        {

            StudentPortal1.DependencyInjection.TeacherLoginCore teacherLoginData = new StudentPortal1.DependencyInjection.TeacherLoginCore(db);
            TeacherLoginController obj = new TeacherLoginController(teacherLoginData);
            var res = obj.DeleteDetail(1);
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);

        }
        [Test]
        public void IsUpdating()
        {
            StudentPortal1.DependencyInjection.TeacherLoginCore teacherLoginData = new StudentPortal1.DependencyInjection.TeacherLoginCore(db);
            TeacherLoginController obj = new TeacherLoginController(teacherLoginData);
            var res = obj.UpdateDetail(1,"abcd");
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);

        }
    }
}