using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Modelos.Estados;

namespace Modelos.Cliente
{
    public class ClienteViewModel
    {
        public int id { get; set; }
        public Nullable<int> id_tipoCliente { get; set; }
        public Nullable<int> id_tipoDoc { get; set; }
        public Nullable<int> nro_doc { get; set; }
        public Nullable<int> id_provincia { get; set; }
        public Nullable<int> id_localidad { get; set; }
        public Nullable<int> cp { get; set; }

        [StringLength(100)]
        [Required]
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }

        [EmailAddress]
        [StringLength (100)]
        [Required]
        public string mail { get; set; }
        public Nullable<int> id_estado { get; set; }



        public class UserExistAttribute : ValidationAttribute
        {

        }



    }
}
