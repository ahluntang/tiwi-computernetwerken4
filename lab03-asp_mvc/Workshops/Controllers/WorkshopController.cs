using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workshops.Models;

namespace Workshops.Controllers
{
    public class WorkshopController : Controller
    {
        //
        // GET: /Workshop/

        public ActionResult Index()
        {
            IWorkshopRepository inwr = (IWorkshopRepository)ControllerContext.HttpContext.Application["data"];
            if (inwr.GetAllWorkshops().Count() > 0)
            {
                return View("Index", inwr.GetAllWorkshops());
            }
            else
            {
                return View("Fout");
            }
        }

        //
        // GET: /Workshop/Details/5

        public ActionResult Details(int id)
        {
            IWorkshopRepository inwr = (IWorkshopRepository)ControllerContext.HttpContext.Application["data"];
            WorkshopWithDetails workshop = inwr.GetWorkshop(id);
            if (workshop != null)
            {
                return View("Detail", workshop);
            }
            else
            {
                Response.StatusCode = 404;
                return null;
            }
        }

        //
        // GET: /Workshop/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Workshop/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            IWorkshopRepository inwr = (IWorkshopRepository)ControllerContext.HttpContext.Application["data"];
            WorkshopWithDetails workshop = new WorkshopWithDetails();
            if (TryUpdateModel(workshop))
            {
                workshop.Id = null;
                inwr.SaveWorkshop(workshop);
                return View("Detail", workshop);
            }
            else {
                return View();
            }
        }
        
        //
        // GET: /Workshop/Edit/5
 
        public ActionResult Edit(int id)
        {

            IWorkshopRepository inwr = (IWorkshopRepository) ControllerContext.HttpContext.Application["data"];

            WorkshopWithDetails workshop = inwr.GetWorkshop(id);
            return View("Edit", workshop);
        }

        //
        // POST: /Workshop/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
                IWorkshopRepository inwr = (IWorkshopRepository) ControllerContext.HttpContext.Application["data"];
                WorkshopWithDetails workshop = inwr.GetWorkshop(id);
                if (TryUpdateModel(workshop))
                {
                    inwr.SaveWorkshop(workshop);
                    return View("Detail", workshop);
                }
                else
                {
                    return View(workshop);
                }
        }

        //
        // GET: /Workshop/Delete/5
 
        public ActionResult Delete(int id)
        {
            IWorkshopRepository inwr = (IWorkshopRepository)ControllerContext.HttpContext.Application["data"];
            inwr.RemoveWorkshop(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Workshop/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IWorkshopRepository inwr = (IWorkshopRepository)ControllerContext.HttpContext.Application["data"];
                inwr.RemoveWorkshop(id);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
