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


        public void inserttest(string nombre)
        {
            Console.Write(nombre);

            
        }
        





    }
}
