using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos.Cliente
{
    public class ClienteViewModel
    {
        public int id { get; set; }
        public Nullable<int> id_tipoCliente { get; set; }
        public Nullable<int> id_tipoDoc { get; set; }
        public Nullable<int> nro_doc { get; set; }
        
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

        public ClienteViewModel()
        {

        }

        public ClienteViewModel(Modelos.Entity.clientes ClienteDB)
        {
            this.id = ClienteDB.id;
            this.id_tipoCliente = ClienteDB.id_tipoCliente;
            this.id_tipoDoc = ClienteDB.id_tipoDoc;
            this.nro_doc = ClienteDB.nro_doc;
            this.cp = ClienteDB.cp;
            this.id_localidad = ClienteDB.id_localidad;
            this.nombre = ClienteDB.nombre;
            this.apellido = ClienteDB.apellido;
            this.domicilio = ClienteDB.domicilio;
            this.telefono = ClienteDB.telefono;
            this.mail = ClienteDB.mail;
            this.id_estado = ClienteDB.id_estado;
        }

        public Modelos.Entity.clientes MapOut()
        {
            Modelos.Entity.clientes ClienteDB = new Modelos.Entity.clientes();
            ClienteDB.id = this.id;
            ClienteDB.id_tipoCliente = this.id_tipoCliente;
            ClienteDB.id_tipoDoc = this.id_tipoDoc;
            ClienteDB.nro_doc = this.nro_doc;
            ClienteDB.id_localidad = this.id_localidad;
            ClienteDB.nombre = this.nombre;
            ClienteDB.apellido = this.apellido;
            ClienteDB.domicilio = this.domicilio;
            ClienteDB.telefono = this.telefono;
            ClienteDB.mail = this.mail;
            ClienteDB.id_estado = this.id_estado;
            ClienteDB.cp = this.cp;

            return ClienteDB;
        }


    }
}
