using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using StudentPortal1.Models;
using StudentPortal1.DependencyInjection;
using StudentPortal1.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace NUnitTest
{
    class StudentLoginTest
    {
        Project_1Context db;
        [SetUp]
        public void Setup()
        {
            var Login = new List<StudentPortal1.Models.StudentLogin>
            {
                new StudentPortal1.Models.StudentLogin { Rollno= 1, Password = "abcd" },
                new StudentPortal1.Models.StudentLogin{ Rollno = 2, Password = "123a" }
            };
            var StudentLoginData = Login.AsQueryable();
            var mockset = new Mock<DbSet<StudentPortal1.Models.StudentLogin>>();
            mockset.As<IQueryable<StudentPortal1.Models.StudentLogin>>().Setup(m => m.Provider).Returns(StudentLoginData.Provider);
            mockset.As<IQueryable<StudentPortal1.Models.StudentLogin>>().Setup(m => m.Expression).Returns(StudentLoginData.Expression);
            mockset.As<IQueryable<StudentPortal1.Models.StudentLogin>>().Setup(m => m.ElementType).Returns(StudentLoginData.ElementType);
            mockset.As<IQueryable<StudentPortal1.Models.StudentLogin>>().Setup(m => m.GetEnumerator()).Returns(StudentLoginData.GetEnumerator());

            var mocksetcontext = new Mock<Project_1Context>();
            mocksetcontext.Setup(c => c.StudentLogin).Returns(mockset.Object);
            db = mocksetcontext.Object;


        }




        [Test]
        public void IsGettingData()
        {
            StudentPortal1.DependencyInjection.StudentLoginCore StudentLoginData = new StudentPortal1.DependencyInjection.StudentLoginCore(db);
          StudentLoginController logob1 = new StudentLoginController(StudentLoginData);
            var res = logob1.GetStudentLogin(1);
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);
        }
        [Test]
        public void IsPostingData()
        {

            StudentPortal1.DependencyInjection.StudentLoginCore studentLoginData = new StudentPortal1.DependencyInjection.StudentLoginCore(db);
            StudentLoginController obj = new StudentLoginController(studentLoginData);
            
            var detail = new StudentPortal1.Models.StudentLogin()
            {
                Rollno = 3,
                Password = "abcd"
            };
            var res = obj.AddDetail(detail);
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);

        }
        [Test]
        public void IsDeletingData()
        {

            StudentPortal1.DependencyInjection.StudentLoginCore teacherLoginData = new StudentPortal1.DependencyInjection.StudentLoginCore(db);
            StudentLoginController obj = new StudentLoginController(teacherLoginData);
            var res = obj.DeleteDetail(1);
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);

        }
        [Test]
        public void IsUpdating()
        {
            StudentPortal1.DependencyInjection.StudentLoginCore teacherLoginData = new StudentPortal1.DependencyInjection.StudentLoginCore(db);
            StudentLoginController obj = new StudentLoginController(teacherLoginData);
            var res = obj.UpdateDetail(1, "abcd");
            var rescheck = res as OkObjectResult;
            Assert.AreEqual(200, rescheck.StatusCode);

        }
    }
}
