using CrudApp.Models;
using CrudApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudApp.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            List<ListClientViewModel> lstCliente = new List<ListClientViewModel>();
            List<ProductoViewModel> lstProducto = new List<ProductoViewModel>();
            List<VentasViewModel> lstVenta = new List<VentasViewModel>();

            List<VentasRelacionViewModel> lstUnida = new List<VentasRelacionViewModel>();

            using (DBEntities db = new DBEntities())
            {
                lstCliente =
                   (from d in db.Cliente
                    orderby d.fecha_creacion descending
                    select new ListClientViewModel
                    {
                        Id = d.id,
                        nombre = d.nombres,
                        apellido = d.apellidos,
                        email = d.email,
                        numero_identificacion = d.numero_identificacion
                    }).ToList();

                lstProducto =
                   (from d in db.Productos
                    orderby d.nombre descending
                    select new ProductoViewModel
                    {
                        Id = d.id,
                        Nombre = d.nombre,
                        Valor = d.valor,
                        Unitario = d.unitario                        
                    }).ToList();

                lstVenta = ( from v in db.Ventas
                             select new VentasViewModel
                             { 
                                id = v.id,
                                id_producto = v.id_producto,
                                id_cliente = v.id_cliente,
                                cantidad = v.cantidad,
                                ValorTotal = v.ValorTotal
                            }).ToList();

                lstUnida = (from c in lstCliente
                            join v in lstVenta
                            on c.Id equals v.id_cliente
                            join p in lstProducto
                            on v.id_producto equals p.Id 
                            select new VentasRelacionViewModel
                            {
                                id = v.id,
                                cliente = c.nombre,
                                producto = p.Nombre,
                                cantidad = v.cantidad,
                                ValorTotal = v.ValorTotal
                            }).ToList();

            }
            return View(lstUnida);
        }
        [HttpGet]
        public ActionResult New() {

            List<CBOClienteViewModel> lstCliente = null;
            List<CBOProductoViewModel> lstProducto = null;

            using (DBEntities db = new DBEntities())
            {
                lstCliente = (from d in db.Cliente
                          select new CBOClienteViewModel
                          {
                              Id = d.id,
                              nombre = d.nombres
                          }).ToList();

                lstProducto = (from d in db.Productos
                          select new CBOProductoViewModel
                          {
                              Id = d.id,
                              nombre = d.nombre
                          }).ToList();

            }

            List<SelectListItem> itemsCl = lstCliente.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> itemsPt = lstProducto.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false

                };
            });

            ViewBag.itemsCliente = itemsCl;
            ViewBag.itemsProducto = itemsPt;

            return View();
        }
        [HttpPost]
        public ActionResult Guardar(VentasViewModel model) {
            try
            {

                using (DBEntities db = new DBEntities())
                {
                    var oVentas = new Ventas();
                    oVentas.id_cliente = model.id_cliente;
                    oVentas.id_producto = model.id_producto;
                    oVentas.cantidad = model.cantidad;
                    oVentas.ValorTotal = model.ValorTotal;

                    db.Ventas.Add(oVentas);
                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/Ventas/"));
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}