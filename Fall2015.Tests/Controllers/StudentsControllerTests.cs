using System;
using Fall2015.Controllers;
using Fall2015.Models;
using Fall2015.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fall2015.Tests.Controllers
{
    [TestClass]
    public class StudentsControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IStudentsRepository> mockRepo = new Mock<IStudentsRepository>();

            StudentsController studentsController = new StudentsController(mockRepo.Object);

            Student s = new Student
            {
                Firstname = "Daniel",
                Lastname = "Something"
            };

            studentsController.Create(s, null);

            mockRepo.Verify(a => a.InsertOrUpdate(s, null));
            mockRepo.Verify(a => a.Save());

        }
    }
}
