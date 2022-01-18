using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Waiter
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string BirthDate { get; set; }
        public int WorkHours { get; set; }

        public Waiter (int _id , string _firstName , string _lastName , string _birthdate, int _workHours)
        {
            this.Id = _id;
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.BirthDate = _birthdate;
            this.WorkHours = _workHours;
        }
        public Waiter () { } 
    }
}