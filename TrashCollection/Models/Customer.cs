using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public DayOfWeek DaysOfTheWeekPickUp { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PickUpStartDateSuspend { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime PickUpEndDateSuspend { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime OneDayPickUp { get; set; }
        public double MonthlyPayment { get; set; }

    }
}