using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudApp.Models.ViewModel
{
    public class ProductoViewModel
    {
        public int Id {set; get;}
        public string Nombre {set; get;}
        public decimal? Valor {set; get;}
        public int? Unitario {set; get;}
    }
    public class NewProductoViewModel
    {
        public int Id { set; get; }
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }
        [Display(Name = "Valor")]
        public decimal? Valor { set; get; }
        [Display(Name = "Unitario")]
        public int? Unitario { set; get; }
    }
    public class EditProductoViewModel
    {
        public int Id { set; get; }
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }
        [Display(Name = "Valor")]
        public decimal? Valor { set; get; }
        [Display(Name = "Unitario")]
        public int? Unitario { set; get; }
    }
    public class CBOProductoViewModel
    {
        public int Id { set; get; }
        public string nombre { set; get; }
    }
}