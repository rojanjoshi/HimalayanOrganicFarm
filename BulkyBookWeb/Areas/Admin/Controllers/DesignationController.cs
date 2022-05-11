using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class DesignationController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DesignationController(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Designation> objCategoryList = _unitOfWork.Designation.GetAll();
        return View(objCategoryList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Designation obj)
    {
        var categoryFromDbFirst = _unitOfWork.Designation.GetFirstOrDefault(u => u.Name == obj.Name);
        if (categoryFromDbFirst == null)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Designation.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Designation created successfully";
                return RedirectToAction("Index");
            }


        }
        else
        {
            TempData["error"] = "Operation Failed! Duplicate Entry";
        }
        
        return View(obj);


    }

    //GET
    public IActionResult Edit(int? id)
    {
        if(id==null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDbFirst = _unitOfWork.Designation.GetFirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Designation obj)
    {
        var categoryFromDbFirst = _unitOfWork.Designation.GetFirstOrDefault(u => u.Name == obj.Name);
        if (categoryFromDbFirst == null)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Designation.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Designation created successfully";
                return RedirectToAction("Index");
            }


        }
        else
        {
            TempData["error"] = "Operation Failed! Duplicate Entry";
        }
        
        return View(obj);

       
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDbFirst = _unitOfWork.Designation.GetFirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFirst);
    }

    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Designation.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Designation.Remove(obj);
            _unitOfWork.Save();
        TempData["success"] = "Designation deleted successfully";
        return RedirectToAction("Index");
        
    }
}
