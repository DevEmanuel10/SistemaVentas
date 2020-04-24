using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controladores
{
    public class ClienteControllers
    {
        Modelos.Entity.DB_4BitsEntities db = new Modelos.Entity.DB_4BitsEntities();


        #region Metodos GetAll, Get, Add, Update and Delete by Neirot
        
        /// <summary>
        /// Get All clientes Mapping from ClienteDB to ClienteVMDatagrid
        /// I delegate responsibility for mapping to Models
        /// Do "AsEnumerable" for next error
        /// https://odetocode.com/blogs/scott/archive/2012/03/20/avoiding-notsupportedexception-with-iqueryable.aspx
        /// </summary>
        /// <returns></returns>
        public List<Modelos.Cliente.ClienteViewModelDataGrid> GetAll() =>
                        db.clientes.AsEnumerable().Select(x => new Modelos.Cliente.ClienteViewModelDataGrid(x)).ToList();

        /// <summary>
        /// ADD Cliente. I do mapping  ClienteVM to ClienteDB
        /// </summary>
        /// <param name="ClienteVM">receive CLIENTE VIEWMODEL</param>
        public void Add(Modelos.Cliente.ClienteViewModel ClienteVM)
        {
            db.clientes.Add(ClienteVM.MapOut());
            db.SaveChanges();
        }
        /// <summary>
        /// Find ClienteDB by Id, Return ClienteVM
        /// </summary>
        /// <param name="id">ID to Find Clinte</param>
        /// <returns></returns>
        public Modelos.Cliente.ClienteViewModel Get(int id) =>
                                    new Modelos.Cliente.ClienteViewModel(db.clientes.FirstOrDefault(x => x.id == id));        
        /// <summary>
        /// Update ClienteVM to ClienteDB
        /// </summary>
        /// <param name="ClinteVM">Generate ClienteVM in View</param>
        public void Update(Modelos.Cliente.ClienteViewModel ClienteVM)
        {
            var ClienteDB = db.clientes.FirstOrDefault(x => x.id == ClienteVM.id); //Busco al cliente a modificar
            db.Entry(ClienteDB).CurrentValues.SetValues(ClienteVM.MapOut());
            db.SaveChanges();
        }
        /// <summary>
        /// Delete ClienteVM to ClienteDB
        /// </summary>
        /// <param name="ClienteVM">Generate ClienteVM in View</param>
        public void Delete(int id)
        {
            //var ClienteDB = db.clientes.FirstOrDefault(x => x.id == id);// Descomentar si lo queres hacer definitivo
            //db.clientes.Remove(ClienteDB); // Descomentar si lo queres hacer definitivo
            //db.SaveChanges(); // Descomentar si lo queres hacer definitivo
            var ClienteVM = new Modelos.Cliente.ClienteViewModel(db.clientes.FirstOrDefault(x => x.id == id));//Comentar si queres hacer definitivo
            ClienteVM.id_estado = db.estados.FirstOrDefault(x => x.nombre == "ELIMINADO").id;//Comentar si queres hacer definitivo
            Update(ClienteVM);//Comentar si queres hacer definitivo
        }


        #endregion








        public List<Modelos.Cliente.ClienteViewModel> GetCliente ()
        {
            using (db)
            {
                List<Modelos.Cliente.ClienteViewModel> cliente = (from d in db.clientes
                                                          select new Modelos.Cliente.ClienteViewModel
                                                          {
                                                              nombre = d.nombre,
                                                              apellido = d.apellido,
                                                              id_tipoDoc = d.id_tipoDoc,
                                                              nro_doc = d.nro_doc,
                                                              id_tipoCliente = d.id_tipoCliente,
                                                              id_localidad = d.id_localidad,
                                                              cp=d.cp,                                                              
                                                              domicilio = d.domicilio,
                                                              mail = d.mail,
                                                              telefono = d.telefono
                                                          }).ToList();
                return cliente;
            }            

        }
      
        public void InsertarCliente(string nombre,
                                    string apellido,
                                    int? tipodoc,
                                    int? nrodoc,
                                    int? tipoCliente,
                                    int? localidad,
                                    int? codPostal,
                                    string domicilio,
                                    string telefono,
                                    string mail                                    
                                     )
        {


            using (Modelos.Entity.DB_4BitsEntities db = new Modelos.Entity.DB_4BitsEntities())
            {
                Modelos.Entity.clientes client = new Modelos.Entity.clientes();

                client.nombre = nombre;
                client.apellido = apellido;
                client.id_tipoDoc = tipodoc;
                client.nro_doc = nrodoc;                
                client.id_localidad = localidad;
                client.cp = codPostal;
                client.domicilio = domicilio;
                client.telefono = telefono;
                client.mail = mail;
                client.id_tipoCliente = tipoCliente;

                db.clientes.Add(client);
                db.SaveChanges();
            }

        }

    }
}
