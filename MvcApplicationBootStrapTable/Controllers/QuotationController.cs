using BusinessLayer;
using MvcApplicationBootStrapTable.Models;
using MvcApplicationBootStrapTable.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWorldSolutions.Models;
using BusinessLayer;
using System.IO;
namespace MvcApplicationBootStrapTable.Controllers
{
    public class QuotationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ReturnQuotationPage()
        {
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

            return PartialView();
        }
        public PartialViewResult ReturnViewEditQuotationPage()
        {
            List<Proposal> lstQuotation = new List<Proposal>();
            DataSet dsProposals = ProposalBL.GetAllProposals();
            if (dsProposals.Tables[0] != null)
            {
                foreach (DataRow row in dsProposals.Tables[0].Rows)
                {
                    lstQuotation.Add
                        (
                            new Proposal
                            {
                                ClientName = row["ClientName"].ToString(),
                                FromDate = Convert.ToDateTime(row["FromDate"].ToString()),
                                NumberOfPersons = Convert.ToInt32(row["NumberOfPersons"]),
                                NumberOfRooms = Convert.ToInt32(row["NumberOfRooms"]),
                                ProposalId = Convert.ToInt32(row["ProposalId"]),
                                ToDate = Convert.ToDateTime(row["ToDate"].ToString()),
                            }
                        );
                }
            }
            return PartialView(lstQuotation);
        }
        public ActionResult FetchHotels(string hotelName, int? stateId, int? cityId)
        {
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

            List<Hotel> lstHotel = new List<Hotel>();

            DataSet dsLstOfHotels = HotelBL.GetAllHotels();
            foreach (DataRow row in dsLstOfHotels.Tables[0].Rows)
            {
                lstHotel.Add
                    (
                         new Hotel
                         {
                             HotelId = Convert.ToInt32(row["Id"]),
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
            //return Json(new { Data = lstHotel }, JsonRequestBehavior.AllowGet); 
            return PartialView("ReturnQuotationPage", lstHotel);
            //return Index();
        }
        public void SaveProposal(Proposal proposal)
        {
            ModelsClassLibrary.Proposal prpsl = new ModelsClassLibrary.Proposal();
            prpsl.ClientName = proposal.ClientName;
            prpsl.FromDate = proposal.FromDate;
            prpsl.listOfHotelIds = proposal.listOfHotelIds;
            prpsl.NumberOfPersons = proposal.NumberOfPersons;
            prpsl.NumberOfRooms = proposal.NumberOfRooms;
            prpsl.ToDate = proposal.ToDate;
            BusinessLayer.ProposalBL.Save(prpsl);
            Response.Redirect("/Quotation#/fetchHotelsForQuotation");
        }
        public JsonResult FetchEmailIds(string term)
        {
            List<string> lstOfEmailIds = new List<string>();
            lstOfEmailIds.Add("poojan1@hotmail.com");
            lstOfEmailIds.Add("poojan2@hotmail.com");
            lstOfEmailIds.Add("poojan3@hotmail.com");
            lstOfEmailIds.Add("poojan4@hotmail.com");
            lstOfEmailIds.Add("poojan5@hotmail.com");
            lstOfEmailIds.Add("poojan6@hotmail.com");
            lstOfEmailIds.Add("poojan7@hotmail.com");
            return Json(lstOfEmailIds, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveAttachments(IEnumerable<HttpPostedFile> formData)
        {
        
            try
            {
                if (Request.Files.Count >0)
                {
                    foreach (string file in Request.Files)
                    {
                        var _file = Request.Files[file];
                        var fileName = Path.GetFileName(_file.FileName);
                        var pathToSaveAttachment = Path.Combine(Server.MapPath("~/Attachments"), fileName);
                        _file.SaveAs(pathToSaveAttachment);
                    }
                    return Json("File/File's uploaded successfully", JsonRequestBehavior.AllowGet);
                   // return RedirectToAction("ReturnViewEditQuotationPage");
                }
                else
                {
                   return Json("Select a file", JsonRequestBehavior.AllowGet);
                   // return RedirectToAction("ReturnViewEditQuotationPage");
                }
            }
            catch (Exception)
            {
                return Json("Error while uploading file", JsonRequestBehavior.AllowGet);
               // return RedirectToAction("ReturnViewEditQuotationPage");
            }
        }
    }
}
