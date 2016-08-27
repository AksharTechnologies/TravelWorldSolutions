using TravelWorldSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationBootStrapTable.Models;
using BusinessLayer;
using System.Data;
namespace TravelWorldSolutions.Controllers
{
    public class Default2Controller : Controller
    {
        public ActionResult Index()
        {
            List<Hotel> lstHotel = new List<Hotel>();

            DataSet dsLstOfHotels = HotelBL.GetAllHotels();
            foreach (DataRow row in dsLstOfHotels.Tables[0].Rows)
            {
                lstHotel.Add
                    (
                         new Hotel
                         {
                             HotelId = Convert.ToInt32(row["Id"]) ,
                             Name = row["Name"].ToString(),
                             ContactPersonName = row["ContactPersonName"].ToString(),
                             ContactNumber = row["ContactNumber"].ToString(),
                             Rating = Convert.ToInt32(row["Rating"]),

                             AddressLine1 = row["AddressLine1"].ToString(),
                             AddressLine2 = row["AddressLine2"].ToString(),
                             City = Convert.ToInt32(row["City"]),
                             State = Convert.ToInt32(row["State"]),
                             Pin = row["Pin"].ToString(),
                             EmailAddress1 = row["EmailAddress1"].ToString(),
                             EmailAddress2 = row["EmailAddress2"].ToString(),
                             HotelType = Convert.ToInt32(row["HotelType"]),
                             PhoneNumber1 = row["PhoneNumber1"].ToString(),
                             PhoneNumber2 = row["PhoneNumber2"].ToString()

                         }
                     );
            }
            List<City> lstCity = new List<City>();
            lstCity.Add(new City { CityId = 0, CityName = "---Select City---" });
            DataSet dsLstCities = new DataSet();
            dsLstCities = CityBL.GetAllCities();
            foreach (DataRow row in dsLstCities.Tables[0].Rows)
            {
                lstCity.Add(new MvcApplicationBootStrapTable.Models.City { CityId = Convert.ToInt32(row["CityId"]), CityName = row["CityName"].ToString() });
            }
            List<MvcApplicationBootStrapTable.Models.State> lstState = new List<MvcApplicationBootStrapTable.Models.State>();
            lstState.Add(new MvcApplicationBootStrapTable.Models.State() { StateId = 0, StateName = "---Select State---" });
            DataSet dsLstState = new DataSet();
            dsLstState = StateBL.GetAllStates();
            foreach (DataRow row in dsLstState.Tables[0].Rows)
            {
                lstState.Add(new MvcApplicationBootStrapTable.Models.State() { StateId = Convert.ToInt32(row["StateId"]), StateName = row["StateName"].ToString() });
            }

            ViewBag.cityDropDown = lstCity.Select(x => new SelectListItem() { Text = x.CityName, Value = x.CityId.ToString() });
            ViewBag.stateDropDown = lstState.Select(x => new SelectListItem() { Text = x.StateName, Value = x.StateId.ToString() });

            return View(lstHotel);
        }
        [HttpPost]
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
            ModelsClassLibrary.Hotel htlModel = new ModelsClassLibrary.Hotel();
            htlModel.HotelId = htl.HotelId;
            htlModel.AddressLine1 = htl.AddressLine1;
            htlModel.AddressLine2 = htl.AddressLine2;
            htlModel.City = htl.City;
            htlModel.ContactNumber = htl.ContactNumber;
            htlModel.ContactPersonName = htl.ContactPersonName;
            htlModel.EmailAddress1 = htl.EmailAddress1;
            htlModel.EmailAddress2 = htl.EmailAddress2;
            htlModel.HotelType = htl.HotelType;
            htlModel.Name = htl.Name;
            htlModel.PhoneNumber1 = htl.PhoneNumber1;
            htlModel.PhoneNumber2 = htl.PhoneNumber2;
            htlModel.Pin = htl.Pin;
            htlModel.Rating = htl.Rating;
            htlModel.State = htl.State;
            if (addOrEditFlag.Trim().ToLower() == "edit")
            {
                HotelBL.Update(htlModel);
            }
            else
            {
                HotelBL.Save(htlModel);
            }
            return RedirectToAction("Index", "Default2");
        }
        public ActionResult DeleteHotel(int id)
        {
            HotelBL.DeleteHotel(id);
            return RedirectToAction("Index", "Default2");
        }
    }
}   
