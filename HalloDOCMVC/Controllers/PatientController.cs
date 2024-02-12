using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HalloDOCMVC.Models;
using Data_Layer.DataModels;
using Data_Layer.Custom_Models;
using Business_Layer.Interface;
using Business_Layer.Repositories;
using Microsoft.EntityFrameworkCore;
using Data_Layer.DataContext;

namespace HalloDOCMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientReq _PatientReq;
        private readonly ApplicationDbContext _context;
        //private readonly IFamilyFrndReq _familyFrndReq;

        public PatientController(IPatientReq patientReq, ApplicationDbContext context /*, IFamilyFrndReq familyFrndReq*/)
        {
            _PatientReq = patientReq;
            _context = context;
            //_familyFrndReq = familyFrndReq;
        }

        public IActionResult Create_pat_req()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_pat_req(PatientReqCM patientReqCM)
        {

            int ReqTypeId = 2;
            try
            {
                _PatientReq.CreateASPuser(patientReqCM, ReqTypeId);
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex;
                return View();
            }
        }

        public IActionResult Create_business_req()
        {
            return View();
        }

        public IActionResult Create_concierge_req()
        {
            return View();
        }

        public IActionResult Create_family_req()
        {
            return View();
        }

        //public IActionResult Create_family_req(FamilyFrndReqCM familyFrndReqCM)
        //{
        //    int ReqTypeId = 3;
        //    try
        //    {
        //        _familyFrndReq.CreateASPuser(familyFrndReqCM, ReqTypeId);
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = ex;
        //        return View();
        //    }
        //}

        public async Task<IActionResult> PatientDashboard()
        {
            return View();
        }

        public IActionResult SubmitSomeoneElse()
        {
            return View();
        }

        public IActionResult SubmitForMe()
        {
            return View();
        }

        public IActionResult PatientProfile()
        {
            return View();
        }

        public IActionResult ViewDocument()
        {
            return View();
        }

        public IActionResult checkEmailAvailibility(string email) //action
        {
            if (email != null)
            {
                Aspnetuser? exist = _context.Aspnetusers.FirstOrDefault(u => u.Email == email);
                if (exist != null)
                {
                    return Json(new { code = 401 });
                }
            }
            return Json(new { code = 402 });
        }

    }
}
