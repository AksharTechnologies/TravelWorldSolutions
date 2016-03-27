using TravelWorldSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TravelWorldSolutions.Controllers
{
    public class Default2Controller : Controller
    {
        public ActionResult Index()
        {
            List<Hotel> lstHotel = new List<Hotel>();
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 5});
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 4 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 3 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 2 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 1 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 5 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 4 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 3 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 2 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 1 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 5 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 4 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 3 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 2 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 1 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 5 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 4 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 3 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 2 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 1 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 5 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 4 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 3 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 2 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 1 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 5 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 4 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 3 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 2 });
            lstHotel.Add(new Hotel { Name = "Name1", ContactPersonName = "ContactPersonName1", ContactNumber = "ContactNumber1", Rating = 1 });
        
            return View(lstHotel);
        }

        public ActionResult AddOrEditDetails(Hotel htl, string addOrEditFlag)
        {
            if (addOrEditFlag.Trim().ToLower() == "edit")
            {
                ViewBag.message = "Successfully Edited";
            }
            if (addOrEditFlag.Trim().ToLower() == "add")
            {
                ViewBag.message = "Successfully Added";
            }
            return RedirectToAction("Index", "Default2");
        }

        public ActionResult DeleteHotel(int id)
        {
            return RedirectToAction("Index", "Default2");
        }
    }
}   
