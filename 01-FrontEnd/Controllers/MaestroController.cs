using Common;
using Model.Domain;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class MaestroController : Controller
    {
        private readonly ITipoDocumentoService _tipoDocumentoService = DependecyFactory.GetInstance<ITipoDocumentoService>();

        // GET: Maestro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud(int id = 0)
        {
            if (id > 0)
            {
                //ViewBag.Courses = _courseService.GetAllByUser(id);
            }

            return View(id == 0 ? new TipoDocumento() : null);
        }

        [HttpPost]
        public ActionResult Crud(TipoDocumento model)
        {
            if (ModelState.IsValid)
            {
                var rh = _tipoDocumentoService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return View(); // RedirectToAction("index");
                }
            }

            return View(model);
        }
    }
}