using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Acciones
    {
        [Key]
        public string Id { get; set; }

        public string DescripcionAccion { get; set; }

        public bool Estado { get; set; }

        public bool Eliminar { get; set; }
    }
}
