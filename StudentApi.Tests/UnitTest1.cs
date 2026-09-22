using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Controllers;
using StudentCRUD.Model;

namespace StudentApi.Tests
{
    public class Tests
    {
        [TestFixture]
        public class StudentControllerTests
        {
            private StudentController _controller;

            [SetUp]
            public void Setup()
            {
                _controller = new StudentController();
            }

            [Test]
            public void GetAll_ReturnsOkResult()
            {
                // Act
                var result = _controller.GetAll();

                // Assert
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }

            //[Test]
            //public void GetById_ExistingId_ReturnsOkResult()
            //{
            //    // Act
            //    var result = _controller.GetById(1);

            //    // Assert
            //    Assert.That(result, Is.TypeOf<OkObjectResult>());
            //}

            [Test]
            public void GetById_InvalidId_ReturnsNotFound()
            {
                // Act
                var result = _controller.GetById(999);

                // Assert
                Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
            }

            [Test]
            public void Add_Student_ReturnsOkResult()
            {
                // Arrange
                var student = new Student
                {
                    Name = "Ahsan"
                };

                // Act
                var result = _controller.Add(student);

                // Assert
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }

            //[Test]
            //public void Update_ExistingStudent_ReturnsOkResult()
            //{
            //    // Arrange
            //    var student = new Student
            //    {
            //        Name = "Ahsan Updated"
            //    };

            //    // Act
            //    var result = _controller.Update(1, student);

            //    // Assert
            //    Assert.That(result, Is.TypeOf<OkObjectResult>());
            //}

            [Test]
            public void Update_InvalidStudent_ReturnsNotFound()
            {
                // Arrange
                var student = new Student
                {
                    Name = "Test"
                };

                // Act
                var result = _controller.Update(999, student);

                // Assert
                Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
            }

            [Test]
            public void Delete_ExistingStudent_ReturnsOkResult()
            {
                // Act
                var result = _controller.Delete(1);

                // Assert
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }

            [Test]
            public void Delete_InvalidStudent_ReturnsNotFound()
            {
                // Act
                var result = _controller.Delete(999);

                // Assert
                Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
            }
        }
    }
}