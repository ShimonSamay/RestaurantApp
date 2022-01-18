using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Chef
    {
        public int Id;
        public string FullName;
        public int Age;
        public string Email;
        public int Wage;

        public Chef (int _id , string _fullname , int _age , string _email , int _wage )
        {
            this.Id = _id;  
            this.FullName = _fullname;
            this.Age = _age;
            this.Email = _email;
            this.Wage = _wage;
        }
    }
}