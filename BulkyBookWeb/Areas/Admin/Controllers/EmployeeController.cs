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
public class EmployeeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    


    public EmployeeController(IUnitOfWork unitOfWork)
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
        EmployeeVm employeeVm = new()
        {
            Employee = new(),
            DepartmentList = _unitOfWork.Department.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            
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
            return View(employeeVm);
        }
        else
        {
            employeeVm.Employee = _unitOfWork.Employee.GetFirstOrDefault(u => u.Id == id);
            return View(employeeVm);

            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(EmployeeVm obj)
    {

        if (ModelState.IsValid)
        {
          
            if (obj.Employee.Id == 0)
            {
                _unitOfWork.Employee.Add(obj.Employee);
            }
            else
            {
                _unitOfWork.Employee.Update(obj.Employee);
            }
            _unitOfWork.Save();
            TempData["success"] = "Employee created successfully";
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
        var productList = _unitOfWork.Employee.GetAll(includeProperties: "Department,Designation");
        return Json(new { data = productList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Employee.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

    

        _unitOfWork.Employee.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}
