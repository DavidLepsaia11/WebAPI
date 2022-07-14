using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces.Services;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PersonService : IPersonService
    {
        private IList<Person> _people;

        public PersonService()
        {
            _people = new List<Person>();
        }

        public decimal CalculateSalary(string uId, string fullName)
        {
            Person selectedPerson = null;
            bool isFound = false;
            if (uId != null)
            {
                selectedPerson = _people.SingleOrDefault(p => p.UId == uId);
                isFound = true;
            }

            if (fullName != null && !isFound)
            {
                selectedPerson = _people.SingleOrDefault(p => p.Fullname == fullName);
            }

            if (selectedPerson == null) throw new Exception("Invalid searching params");

            selectedPerson.JobEndDate ??= DateTime.Today;

            var workingDays = (selectedPerson.JobEndDate - selectedPerson.JobStartDate).Value.Days;

            return selectedPerson.DailySalary * workingDays;
        }

        public void Register(Person person)
        {
            bool isRegistered = _people.Any(p => p.UId == person.UId);

            if (isRegistered)
            {
                throw new Exception("Such user has already been registered");
            }

            if (person.Fullname.Length < 5)
            {
                throw new Exception("Fullname length must be more then 5");
            }

            _people.Add(person);
        }
    }
}
