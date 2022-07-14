using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces.Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("Register")]
        public void Register(string uid, string fullName, DateTime jobStartDate, DateTime jobEndDate, decimal dailySalary)
        {
            var person = new Person()
            {
                DailySalary = dailySalary,
                Fullname = fullName,
                UId = uid,
                JobStartDate = jobStartDate,
                JobEndDate = jobEndDate
            };

            _personService.Register(person);
        }

        [HttpGet("CalculateSalary")]
        public decimal CalculateSalary(string uid, string fullName)
        {
            var result = _personService.CalculateSalary(uid, fullName);

            return result;
        }
    }
}
