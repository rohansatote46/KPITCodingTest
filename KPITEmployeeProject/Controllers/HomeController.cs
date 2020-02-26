using KPITEmployeeProject.infrastructure.Services.Impl;
using KPITEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KPITEmployeeProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private EmployeeService _empService;
        private CountryService _countryService;
        private StateService _stateService;
        private GenderService _genderService;
        private MaritalStatusService _MaritalStatusService;
        private DepartmentService _DepartmentService;
        public HomeController()
        {
            _empService = new EmployeeService();
            _countryService = new CountryService();
            _stateService = new StateService();
            _genderService = new GenderService();
            _MaritalStatusService = new MaritalStatusService();
            _DepartmentService = new DepartmentService();
        }
        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult Init()
        {
            tblEmployee _empObj = new tblEmployee();
            _empObj.CRUD = "I";

            var CountryList = _countryService.GetAll().Select(s => new { s.CountryId,s.CountryName}).ToList();
            var StateList = _stateService.GetAll().Select(s => new { s.StateId, s.StateName,s.CountryId }).ToList();
            var GenderList = _genderService.GetAll().Select(s => new { s.Id, s.Description }).ToList();
            var MaritalStatusList = _MaritalStatusService.GetAll().Select(s => new { s.Id, s.Description }).ToList();
            var DepartmentList = _DepartmentService.GetAll().Select(s => new { s.DeptId, s.DeptName }).ToList();

            var EmployeeList = _empService.GetAll().Select(s => new
            {
                s.Id,
                FullName = s.FirstName+ " "+s.LastName,
                s.Email,
                s.EmpCode,
                s.MobileNo,
                CRUD = "U",
                s.CreatedDate,
                s.ModifiedDate
            }).OrderByDescending(s => s.CreatedDate).Take(10).ToList();

            string[] detailArr = new string[1];
            var detail = (from d in detailArr
                          select new
                          {
                              _empObj = _empObj,
                              EmployeeList = EmployeeList,
                              CountryList= CountryList,
                              StateList = StateList,
                              GenderList = GenderList,
                              MaritalStatusList = MaritalStatusList,
                              DepartmentList = DepartmentList
                          }).FirstOrDefault();

            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindById(int Id)
        {
            var _empObj = _empService.FindById(Id);

            if (_empObj != null)
            {
                _empObj.CRUD = "U";
            }
            return Json(_empObj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(tblEmployee pEmpObj)
        {
           
            try
            {                
                if (pEmpObj.CRUD == "I")
                {
                    pEmpObj.EmpCode = "EMP0" + (_empService.GetAll().Count() + 1);
                    pEmpObj.CreatedBy = 1;
                    pEmpObj.CreatedDate = DateTime.Now;

                    var result = _empService.Save(pEmpObj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    pEmpObj.ModifiedBy = 1;
                    pEmpObj.ModifiedDate = DateTime.Now;

                    var result = _empService.Update(pEmpObj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SearchEmployee(string SearchText)
        {
            var result = _empService.SearchEmployees(SearchText.Trim()).Select(s => new
            {
                s.Id,
                FullName = s.FirstName + " " + s.LastName,
                s.Email,
                s.EmpCode,
                s.MobileNo,
                CRUD = "U",
                s.CreatedDate,
                s.ModifiedDate
            }).OrderByDescending(s => s.CreatedDate).Take(10).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            var _empObj = _empService.FindById(Id);
            var result = _empService.Delete(_empObj);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}