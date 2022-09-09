using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudApp.Models.ViewModel
{
    public class EditClientViewModel
    {

        public int id { get; set; }
        [Required]        
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos (1) caracter ", MinimumLength = 1)]
        [Display(Name = "Nombres")]
        public string nombres { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos (1) caracter ", MinimumLength = 1)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos (1) caracter ", MinimumLength = 1)]
        [Display(Name = "# identificacion")]
        public string numero_identificacion { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos (1) caracter ", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]

        public string email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos (1) caracter ", MinimumLength = 1)]
        [Display(Name = "Telefono")]

        public string telefono { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos (1) caracter ", MinimumLength = 1)]
        [Display(Name = "Tipo Identificacion")]
        public string tipo_identificacion { get; set; }

        public Nullable<System.DateTime> fecha_creacion { get; set; }
    }
}