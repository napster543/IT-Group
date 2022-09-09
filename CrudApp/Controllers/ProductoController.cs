using CrudApp.Models;
using CrudApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudApp.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ProductoViewModel> lst = new List<ProductoViewModel>();
            using (DBEntities db = new DBEntities())
            {
                lst =
                   (from d in db.Productos
                    orderby d.nombre descending
                    select new ProductoViewModel
                    {
                        Id = d.id,
                        Nombre = d.nombre,
                        Valor = d.valor,
                        Unitario = d.unitario,
                    }).ToList();
            }
            return View(lst);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(NewProductoViewModel model)
        {
            try
            {
                DateTime hoy = DateTime.Now;
                using (DBEntities db = new DBEntities())
                {
                    var oProducto = new Productos();
                    oProducto.id = model.Id;
                    oProducto.nombre = model.Nombre;
                    oProducto.valor = model.Valor;
                    oProducto.unitario = model.Unitario;
                    db.Productos.Add(oProducto);
                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/Producto/"));
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {

            DateTime hoy = new DateTime();
            EditProductoViewModel model = new EditProductoViewModel();
            using (DBEntities db = new DBEntities())
            {
                var oProducto = db.Productos.Find(id);
                model.Id = id;
                model.Nombre = oProducto.nombre;
                model.Valor = oProducto.valor;
                model.Unitario = oProducto.unitario;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditProductoViewModel model)
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
                    var oProducto = db.Productos.Find(model.Id);

                    oProducto.nombre = model.Nombre;
                    oProducto.valor = model.Valor;
                    oProducto.unitario = model.Unitario;

                    db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/Producto/"));
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {

            using (DBEntities db = new DBEntities())
            {
                var oMateria = db.Productos.Find(id);
                db.Entry(oMateria).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Producto/"));
        }

    }
}