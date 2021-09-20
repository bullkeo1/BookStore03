using System.Threading.Tasks;
using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;
using BulkyBook03.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook03.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            return  View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                //this is for create
                return View(category);
            }
            //this is for edit
            category = await _unitOfWork.Category.GetAsync(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                     await _unitOfWork.Category.AddAsync(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
        #region API CALLS

        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Category.GetAllAsync();
            return Json(new {data = allObj});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Category.GetAsync(id);
            if (objFromDb == null)
            {
                // TempData["Error"] = "Error while deleting Category";
                return Json(new {success = false, message = "Error while deleting"});
            }

            await _unitOfWork.Category.RemoveAsync(objFromDb);
            _unitOfWork.Save();
            // TempData["Success"] = "This Category was deleted successfully";
            return Json(new {success = true, message = "Delete successfully"});

        }
        #endregion
    }
}
    
