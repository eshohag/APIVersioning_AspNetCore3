using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UMS.Entities.Students;

namespace HttpHeaderBased_APIVersioning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet, MapToApiVersion("1.0")]
        public IEnumerable<Student> Student1()
        {
            return new List<Student>() {
                new Student { Id = 1, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Shohag", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
            };
        }

        [HttpGet, MapToApiVersion("2.0")]
        public IEnumerable<Student> Student2()
        {
            return new List<Student>() {
                new Student { Id = 1, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Shohag", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
                new Student { Id = 2, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Arif", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
            };
        }

        [HttpGet, MapToApiVersion("3.0")]
        public IEnumerable<Student> Student3()
        {
            return new List<Student>() {
                new Student { Id = 1, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Shohag", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
                new Student { Id = 2, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Arif", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
                new Student { Id = 3, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Milon", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
            };
        }
    }
}
