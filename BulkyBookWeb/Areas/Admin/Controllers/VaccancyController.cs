using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]
[Authorize]
public class VaccancyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    


    public VaccancyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
    }
    
    public IActionResult Index()
    {
       return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        VaccancyVm vaccancyVm = new()
        {
            Vaccancy = new(),
   
            
            DesignationList = _unitOfWork.Designation.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),

        };

        if (id == null || id == 0)
        {
            //create product
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(vaccancyVm);
        }
        else
        {
            vaccancyVm.Vaccancy = _unitOfWork.Vaccancy.GetFirstOrDefault(u => u.Id == id);
            return View(vaccancyVm);

            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(VaccancyVm obj)
    {

        if (ModelState.IsValid)
        {
          
            if (obj.Vaccancy.Id == 0)
            {
                _unitOfWork.Vaccancy.Add(obj.Vaccancy);
            }
            else
            {
                _unitOfWork.Vaccancy.Update(obj.Vaccancy);
            }
            _unitOfWork.Save();
            TempData["success"] = "Vaccancy created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    [HttpGet]
    public JsonResult getempsalary(int designationid)
    {
        int salary = _unitOfWork.Salary.GetFirstOrDefault(u => u.DesignationId == designationid).TSalary;
        return Json(salary);

    }


    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var productList = _unitOfWork.Vaccancy.GetAll(includeProperties: ",Designation");
        return Json(new { data = productList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Vaccancy.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

    

        _unitOfWork.Vaccancy.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}
