using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;
using BulkyBook03.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBook03.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Get
        public IActionResult Upsert(int? id)
        {
            Company company = new Company();
            //for create
            if (id == null)
            {
                return View(company);
            }

            company = _unitOfWork.Company.Get(id.GetValueOrDefault());
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                //create
                if (company.Id == 0)
                {
                   _unitOfWork.Company.Add(company);
                }
                //edit
                else
                {
                    _unitOfWork.Company.Update(company);
                   
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
                
            }
            return View(company);
        }

        #region APICall

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Company.GetAll();
            return Json(new {data = allObj});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Company.Get(id);
            if (objFromDb == null)
            {
                return Json(new {success = false, message = "Error while deleting!!"});
            }
            else
            {
                _unitOfWork.Company.Remove(objFromDb);
                _unitOfWork.Save();
                return Json(new {success = true, message = "Deleted successfully!!"});

            }
        }

        #endregion
    }
    
}