using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Web.Models
{
    public class Empleado
    {
        public int id { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        [StringLength(5)]
        public string dni { get; set; }
        [Required(ErrorMessage = "* Requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "* Requerido")]
        public string apellido_p { get; set; }
        [Required(ErrorMessage = "* Requerido")]
        public string apellido_m { get; set; }
        [Required(ErrorMessage = "* Requerido")]
        public DateTime fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "* Requerido")]
        public string sexo { get; set; }
        public bool estado { get; set; }
        [Required(ErrorMessage = "* Requerido")]
        public string Area { get; set; }
        public DateTime fecha_registro { get; set; }
        public string usuario_registro { get; set; }
    }
}
