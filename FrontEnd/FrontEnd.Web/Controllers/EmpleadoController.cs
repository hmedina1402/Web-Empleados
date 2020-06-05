using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Util.Utils;
using FrontEnd.Service.Interfaces;
using FrontEnd.Service.Entidades;
using Microsoft.Extensions.Options;

namespace FrontEnd.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleado empleado;

        public EmpleadoController(IEmpleado empleado)
        {
            this.empleado = empleado;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listado()
        {
            var lstEmpleado = empleado.Listado();
            return Json(new { data = lstEmpleado.Result });
        }

        [HttpPost]
        public ActionResult Registro(Ent_Empleado ent_Empleado)
        {
            var strResultado = empleado.Insertar(ent_Empleado);
            return Json(new { data = strResultado.Result });
        }

    }
}