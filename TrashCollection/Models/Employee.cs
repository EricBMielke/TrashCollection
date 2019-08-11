using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public DayOfWeek DaysOfTheWeekToPickUp { get; set; }
        public string CustomersToPickUpDuringWeek { get; set; }
        public string CustomersToPickUpToday { get; set; }


    }
}