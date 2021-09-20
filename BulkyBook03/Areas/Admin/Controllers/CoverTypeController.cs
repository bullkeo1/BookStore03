using System.Threading.Tasks;
using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;
using BulkyBook03.Utility;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook03.Areas.Admin.Controllers


    {
 [Area("Admin")]
   [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            CoverType coverType =new CoverType();
            if (id == null)
            {
                return View(coverType);
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Id",id);
            coverType = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, parameter);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Name", coverType.Name);
                if (coverType.Id == 0)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Create, parameter);
                }
                else
                {
                    parameter.Add("@Id", coverType.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Update, parameter);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }
        #region Api Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SP_Call.List<CoverType>(SD.Proc_CoverType_GetAll);
            return Json(new {data = allObj});
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id",id);
            var objFromDb = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, parameter);
            if (objFromDb == null)
            {
                return Json(new {success = false, message = "Error while Deleting"});
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Delete,parameter);
            _unitOfWork.Save();
            return Json(new {success = true, message = "Delete successful"});
        }
        #endregion
    }
}