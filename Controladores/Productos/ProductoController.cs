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

        public List<Modelos.Productos.ProductoViewModelDataGrid> GetAll() =>
                    DB.productos.AsEnumerable().Select(x => new Modelos.Productos.ProductoViewModelDataGrid(x)).ToList();

        //public Modelos.Cliente.ClienteViewModel Get(int id) =>
        //                    new Modelos.Cliente.ClienteViewModel(db.clientes.FirstOrDefault(x => x.id == id));

        public Modelos.Productos.ProductosViewModel Get(int id) =>
                              new Modelos.Productos.ProductosViewModel(DB.productos.FirstOrDefault(x => x.id == id));


        //pruebo
        public Modelos.Productos.ProductosViewModel GetUnidad(string nombre) =>
                             new Modelos.Productos.ProductosViewModel(DB.productos.FirstOrDefault(x => x.nombre == nombre));


        public void Update(Modelos.Productos.ProductosViewModel ProductoVM)
        {
            var ProductoDB = DB.productos.FirstOrDefault(x => x.id == ProductoVM.id); //Busco al cliente a modificar
            DB.Entry(ProductoDB).CurrentValues.SetValues(ProductoVM.MapOut());
            DB.SaveChanges();
        }

        public void Delete(int idProducto)
        {
            //var ClienteDB = db.clientes.FirstOrDefault(x => x.id == id);// Descomentar si lo queres hacer definitivo
            //db.clientes.Remove(ClienteDB); // Descomentar si lo queres hacer definitivo
            //db.SaveChanges(); // Descomentar si lo queres hacer definitivo
            var ProductoVM = new Modelos.Productos.ProductosViewModel(DB.productos.FirstOrDefault(x => x.id == idProducto));//Comentar si queres hacer definitivo  -TRAE TODOS LOS ELEMENTOS DE PRODUCTOS
            ProductoVM.id_estado = DB.estados.FirstOrDefault(x => x.nombre == "ELIMINADO").id;//Comentar si queres hacer definitivo
            Update(ProductoVM);//Comentar si queres hacer definitivo
        }

    }
}
