using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository;
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
[Authorize(Roles = SD.Role_Admin)]
public class SalaryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    


    public SalaryController(IUnitOfWork unitOfWork)
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
        SalaryVm salaryVm = new()
        {
            Salary = new(),
         
            
            DesignationList = _unitOfWork.Designation.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            //CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //}),
        };

        if (id == null || id == 0)
        {
            //create product
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(salaryVm);
        }
        else
        {
            salaryVm.Salary = _unitOfWork.Salary.GetFirstOrDefault(u => u.Id == id);
            return View(salaryVm);

            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(SalaryVm obj)
    {

        //var designationame = _unitOfWork.Salary.GetFirstOrDefault(u => u.DesignationId == obj.Salary.DesignationId).Designation.Name;
        var designationfromdb = _unitOfWork.Salary.GetFirstOrDefault(u => u.DesignationId == obj.Salary.DesignationId);
        if (designationfromdb == null)
        {
            if (ModelState.IsValid)
            {


                if (obj.Salary.Id == 0)
                {
                    _unitOfWork.Salary.Add(obj.Salary);

                }
                else
                {
                    _unitOfWork.Salary.Update(obj.Salary);

                }




                _unitOfWork.Save();
                TempData["success"] = "Salary created successfully";
                return RedirectToAction("Index");
            }

        }
        else
        {
            TempData["error"] = "Operation Failed! Duplicate Entry";
        }


        return RedirectToAction("Index");
    }
 

     


       
        






        #region API CALLS
        [HttpGet]
    public IActionResult GetAll()
    {
        var productList = _unitOfWork.Salary.GetAll(includeProperties: "Designation");
        return Json(new { data = productList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Salary.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

    

        _unitOfWork.Salary.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}
