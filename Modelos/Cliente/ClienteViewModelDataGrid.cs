using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Cliente
{
    public class ClienteViewModelDataGrid
    {
        public int id { get; set; }
        public string Cliente { get; set; }
        public string Tipo_Cliente { get; set; }
        public string Nro_Doc { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Domicilio { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public Nullable<int> Cod_Postal { get; set; }
        public string Estado { get; set; }

        public ClienteViewModelDataGrid()
        {

        }
        public ClienteViewModelDataGrid(Entity.clientes miObjeto)
        {
            Entity.DB_4BitsEntities db = new Entity.DB_4BitsEntities();

            this.id = miObjeto.id;
            this.Cliente = miObjeto.nombre + " " + miObjeto.apellido;
            this.Tipo_Cliente = db.tipo_Clientes.FirstOrDefault(x => x.id == miObjeto.id_tipoCliente).nombre;
            this.Nro_Doc = db.tipo_Doc.FirstOrDefault(x => x.id == miObjeto.id_tipoDoc).nombre + ": " + miObjeto.nro_doc;
            this.Telefono = miObjeto.telefono;
            this.Mail = miObjeto.mail;
            this.Domicilio = miObjeto.domicilio;

            this.Provincia = db.Provincias.FirstOrDefault(x => x.ID ==
                                 db.Departamentos.FirstOrDefault(y => y.ID ==
                                    db.Localidades.FirstOrDefault(z => z.ID == miObjeto.id_localidad).
                                        idDepartamento).idProvincia).Nombre;

            this.Departamento = db.Departamentos.FirstOrDefault(x => x.ID ==
                                   db.Localidades.FirstOrDefault(y => y.ID == miObjeto.id_localidad).idDepartamento).Nombre;

            this.Localidad = db.Localidades.FirstOrDefault(x => x.ID == miObjeto.id_localidad).Nombre;

            this.Cod_Postal = miObjeto.cp;
            this.Estado = db.estados.FirstOrDefault(x => x.id == miObjeto.id_estado).nombre;
        }
    }
}
