using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controladores.Productos
{
    public class ProductoController
    {
        Modelos.Entity.DB_4BitsEntities DB = new Modelos.Entity.DB_4BitsEntities();
        public void Add(Modelos.Productos.ProductosViewModel productoVM) //funcion agregar
        {

            DB.productos.Add(productoVM.MapOut());
            DB.SaveChanges();

            
        }
    }
}
