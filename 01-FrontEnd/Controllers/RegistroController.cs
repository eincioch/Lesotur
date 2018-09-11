using Common;
using Model.Custom;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class RegistroController : Controller
    {
        private readonly IPersonaService _personaService = DependecyFactory.GetInstance<IPersonaService>();
       

        // GET: Persona
        public ActionResult Index()
        {

            return View(_personaService.GetAll());
        }

        public ActionResult Crud(int id = 0)
        {
            if (id > 0)
            {
                //ViewBag.Courses = _courseService.GetAllByUser(id);
            }

            return View(id == 0 ? new Persona() : null);
        }

        [HttpPost]
        public ActionResult Crud(Persona model)
        {
            if (ModelState.IsValid)
            {
                var rh = _personaService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
    }
}