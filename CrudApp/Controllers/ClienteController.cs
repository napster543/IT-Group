using CrudApp.Models;
using CrudApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudApp.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            List<ListClientViewModel> lst = new List<ListClientViewModel>();
            using (DBEntities db = new DBEntities())
            {
                lst =
                   (from d in db.Cliente
                    orderby d.nombres descending
                    select new ListClientViewModel
                    {
                        Id = d.id,
                        nombre = d.concat_nombre_apellido,
                        apellido = d.apellidos,
                        numero_identificacion = d.numero_identificacion,
                        email = d.email,
                        tipo_identificacion = d.tipo_identificacion,
                        telefono = d.telefono,
                        fecha_creacion = d.fecha_creacion
                    }).ToList();
            }
            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(ClienteViewModel model)
        {
            try
            {
                DateTime hoy = DateTime.Now;
                using (DBEntities db = new DBEntities())
                {
                    var oCliente = new Cliente();
                    oCliente.nombres = model.nombres;
                    oCliente.apellidos = model.apellidos;
                    oCliente.numero_identificacion = model.numero_identificacion;
                    oCliente.email = model.email;
                    oCliente.telefono = model.telefono;
                    oCliente.tipo_identificacion = model.tipo_identificacion;
                    oCliente.fecha_creacion = hoy;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();
                }
                return Content("1");
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            DateTime hoy = new DateTime();
            EditClientViewModel model = new EditClientViewModel();
            using (DBEntities db = new DBEntities())
            {
                var oPersona = db.Cliente.Find(Id);
                model.id = Id;
                model.nombres = oPersona.nombres;
                model.apellidos = oPersona.apellidos;
                model.numero_identificacion = oPersona.numero_identificacion;
                model.email = oPersona.email;
                model.telefono = oPersona.telefono;
                model.tipo_identificacion = oPersona.tipo_identificacion;
                model.fecha_creacion = hoy;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                DateTime hoy = DateTime.Now;
                using (DBEntities db = new DBEntities())
                {
                    var oPersona = db.Cliente.Find(model.id);
                    oPersona.nombres = model.nombres;
                    oPersona.apellidos = model.apellidos;
                    oPersona.numero_identificacion = model.numero_identificacion;
                    oPersona.telefono = model.telefono;
                    oPersona.email = model.email;
                    oPersona.tipo_identificacion = model.tipo_identificacion;
                    oPersona.fecha_creacion = hoy;

                    db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/Cliente/"));
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (DBEntities db = new DBEntities())
            {
                var oPersona = db.Cliente.Find(id);
                db.Entry(oPersona).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}