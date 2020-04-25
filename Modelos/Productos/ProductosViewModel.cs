using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Productos
{
    public class ProductosViewModel
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<int> id_unidad { get; set; }
        

        public ProductosViewModel()
        {

        }


        public ProductosViewModel(Modelos.Entity.productos productosDB)   //pasa de bd a vista
        {
            this.id = productosDB.id;
            this.codigo = productosDB.categoria;
            this.categoria = productosDB.categoria;
            this.nombre = productosDB.nombre;
            this.descripcion = productosDB.descripcion;
            this.id_estado = productosDB.id_estado;
            this.id_unidad = productosDB.id_unidad;
                         
        }


        public Modelos.Entity.productos MapOut()  //pasa de vista a bd
        {
            Modelos.Entity.productos productosDB = new Modelos.Entity.productos();

            productosDB.id = this.id;
            productosDB.codigo = this.categoria;
            productosDB.categoria = this.categoria;
            productosDB.nombre = this.nombre;
            productosDB.descripcion = this.descripcion;
            productosDB.id_estado = this.id_estado;
            productosDB.id_unidad = this.id_unidad;

            
            return productosDB;
        }


    }

    

}
