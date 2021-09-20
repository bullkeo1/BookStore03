using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;
using BulkyBook03.Models.ViewModels;
using BulkyBook03.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook03.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        // GET
        public async Task <IActionResult> Index()
        {
            return View();
        }

        public async Task <IActionResult> Upsert(int? id)
        {
            var CatList = await _unitOfWork.Category.GetAllAsync();
            ProductVM productVm = new ProductVM()
            {
               
                Product = new Product(),
                CategoryList = CatList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i=>new SelectListItem
                {
                    Text=i.Name,
                    Value=i.Id.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(productVm);
            }
//this is for edit
            productVm.Product = _unitOfWork.Product.Get(id.GetValueOrDefault());
            if (productVm.Product == null)
            {
                return NotFound();
            }

            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Upsert(ProductVM productVm)
        {
            IEnumerable<Category> CatList = await _unitOfWork.Category.GetAllAsync();
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images/products");
                    var extension = Path.GetExtension(files[0].FileName);
                    if (productVm.Product.ImageUrl != null)
                    {
                        //to edit path so we need to delete the old path and update new one
                        var imagePath = Path.Combine(webRootPath, productVm.Product.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    using (var filesStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        await files[0].CopyToAsync(filesStream);
                    }

                    productVm.Product.ImageUrl = @"/images/products/" + fileName + extension;
                }
                else
                {
                    //update without change the images
                    if (productVm.Product.Id != 0)
                    {
                        Product objFromDb = _unitOfWork.Product.Get(productVm.Product.Id);
                        productVm.Product.ImageUrl = objFromDb.ImageUrl; //vi ko upload anh moi nen lay anh cu trong db
                    }
                }

                if (productVm.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVm.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVm.Product);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
               
                productVm.CategoryList = CatList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                productVm.CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                if (productVm.Product.Id != 0)
                {
                    productVm.Product = _unitOfWork.Product.Get(productVm.Product.Id);
                }
            }

            return View(productVm);
        }

        #region API CALLS

        public async Task <IActionResult> GetAll()
        {
            var allObj =  _unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");
            var responseData = Json(new {data = allObj});
            return responseData;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Product.Get(id);
            if (objFromDb == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            //to edit path so we need to delete the old path and update new one
            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(imagePath))
            {
               System.IO.File.Delete(imagePath); 
            }
            _unitOfWork.Product.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new {success = true, message = "Delete successful"});
            
        }
        #endregion
    }
}
    
