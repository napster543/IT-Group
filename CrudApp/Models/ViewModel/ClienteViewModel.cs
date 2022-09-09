using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudApp.Models.ViewModel
{
    public class ClienteViewModel
    {
        [Display(Name = "Nombres")]
        public string nombres { get; set; }
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Display(Name = "# identificacion")]
        public string numero_identificacion { get; set; }
        [Display(Name = "Correo Electronico")]
        public string email { get; set; }
        [Display(Name = "Tipo Identificacion")]
        public string tipo_identificacion { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        public string fecha_creacion { get; set; }
    }

    public class CBOClienteViewModel
    {
        public int Id { set; get; }
        public string nombre { set; get; }
    }


}