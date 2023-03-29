using System;
using System.Collections.Generic;
using edu_services.Controllers;
using edu_services.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace edu_services.Tests
{
    public class UnitTest
    {
        private readonly ApiController _apiController;

        public UnitTest()
        {
            var logger = new LoggerFactory().CreateLogger<ApiController>();
            _apiController = new ApiController(logger);
        }

        [Fact]
        public void AddTeacher_ReturnsOkResult_WhenTeacherIsValid()
        {
            // Arrange
            var teacher = new Teacher { FirstName = "John", LastName = "Smith" };

            // Act
            var result = _apiController.AddTeacher(teacher);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.IsType<Teacher>(okObjectResult.Value);
            Assert.Equal(teacher, okObjectResult.Value as Teacher);
        }

        [Fact]
        public void AddTeacher_ReturnsBadRequestResult_WhenTeacherIsNull()
        {
            // Arrange
            Teacher? teacher = null;

            // Act
            var result = _apiController.AddTeacher(teacher);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void AddStudent_ReturnsOkResult_WhenStudentIsValid()
        {
            // Arrange
            var student = new Student { FirstName = "Jane", LastName = "Doe" };

            // Act
            var result = _apiController.AddStudent(student);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.IsType<Student>(okObjectResult.Value);
            Assert.Equal(student, okObjectResult.Value as Student);
        }

        [Fact]
        public void AddStudent_ReturnsBadRequestResult_WhenStudentIsNull()
        {
            // Arrange
            Student? student = null;

            // Act
            var result = _apiController.AddStudent(student);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void GetRoster_ReturnsOkObjectResult_WhenClassroomIsValid()
        {
            // Arrange
            var data = new List<object>
            {
                new Teacher { FirstName = "John", LastName="Smith" },
                new Student { FirstName = "Jane", LastName="Doe" },
                new Student { FirstName = "Bob", LastName="Smith" },
                new Student { FirstName = "Emily", LastName="Jones" }
            };

            _apiController.AddTeacher(data[0] as Teacher);
            _apiController.AddStudent(data[1] as Student);
            _apiController.AddStudent(data[2] as Student);

            // Act
            var result = _apiController.GetRoster();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);

            _apiController.AddStudent(data[3] as Student);

            // Act
            result = _apiController.GetRoster();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.Equal(data, okObjectResult.Value as List<object>);

        }
    }
}
