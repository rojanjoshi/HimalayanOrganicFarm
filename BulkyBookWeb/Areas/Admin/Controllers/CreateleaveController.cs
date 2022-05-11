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
public class CreateleaveController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    


    public CreateleaveController(IUnitOfWork unitOfWork)
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
        CreateLeaveVm createLeaveVm = new()
        {
            CreateLeave = new(),
            EmployeeList = _unitOfWork.Employee.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            
            LeaveTypeList = _unitOfWork.Leave.GetAll().Select(i => new SelectListItem
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
            return View(createLeaveVm);
        }
        else
        {
            createLeaveVm.CreateLeave = _unitOfWork.CreateLeave.GetFirstOrDefault(u => u.Id == id);
            return View(createLeaveVm);

            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(CreateLeaveVm obj)
    {

        if (ModelState.IsValid)
        {
          
            if (obj.CreateLeave.Id == 0)
            {
                _unitOfWork.CreateLeave.Add(obj.CreateLeave);
            }
            else
            {
                _unitOfWork.CreateLeave.Update(obj.CreateLeave);
            }
            _unitOfWork.Save();
            TempData["success"] = "CreateLeave created successfully";
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
        var productList = _unitOfWork.CreateLeave.GetAll(includeProperties: "Employee,Leave");
        return Json(new { data = productList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.CreateLeave.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

    

        _unitOfWork.CreateLeave.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}
