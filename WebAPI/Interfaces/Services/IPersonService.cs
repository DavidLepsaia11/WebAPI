﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces.Services
{
    public interface IPersonService
    {
        public void Register(Person person);

        public decimal CalculateSalary(string uId, string fullName);
    }
}
