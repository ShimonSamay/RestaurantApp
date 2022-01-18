using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class ChefController : Controller
    {
         List<Chef> ChefsList = new List<Chef>();
        public ActionResult Name()
        {
            fillList();
            return View(ChefsList[ChefsList.Count-1]);
        }

        public ActionResult Chef(int id)
        {
            fillList();
            ViewBag.Chef = ChefsList.Find(chef => chef.Id == id);
            return View();
        }

        public void fillList ()
        {
            ChefsList.Add(new Chef(1,"avi" , 28 , "avi@" , 2300));
            ChefsList.Add(new Chef(2, "shimon", 22, "shimon@", 3999));
            ChefsList.Add(new Chef(3, "oshri", 25, "oshri@", 7888));
            ChefsList.Add(new Chef(4, "amir", 98, "amir@",3000));
            ChefsList.Add(new Chef(5, "eli", 38, "eli@", 1898));
        }
    }
}