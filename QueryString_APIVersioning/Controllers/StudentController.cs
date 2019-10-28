﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.Entities.Students;

namespace QueryString_APIVersioning.Controllers
{

    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    //[ApiVersion("3.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IEnumerable<Student> Student1()
        {
            return new List<Student>() {
                new Student { Id = 1, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Shohag", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
            };
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<Student> Student2()
        {
            return new List<Student>() {
                new Student { Id = 1, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Shohag", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
                new Student { Id = 2, CreatedDate = DateTime.Now, CreatedUserId = 101, DepartmentId = 1, EnrollmentDate = DateTime.Now, FullName = "Arif", IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 101 },
            };
        }

        [MapToApiVersion("3.0")]
        [HttpGet]
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