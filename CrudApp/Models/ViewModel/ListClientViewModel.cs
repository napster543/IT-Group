using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApp.Models.ViewModel
{
    public class ListClientViewModel
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string numero_identificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string tipo_identificacion { get; set; }
        public DateTime? fecha_creacion { get; set; }
    }
}