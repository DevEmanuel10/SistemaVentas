using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class DepartamentoController
    {
        Modelos.Entity.DB_4BitsEntities dbtest = new Modelos.Entity.DB_4BitsEntities();
             

        public List<Modelos.Departamentos.DepartamentoViewModel> getDepartamento()
        {
            Modelos.Entity.DB_4BitsEntities db = new Modelos.Entity.DB_4BitsEntities();

            using (db)
            {
                List<Modelos.Departamentos.DepartamentoViewModel> departamentos =
                                                                                    (from d in db.Departamentos
                                                                                     select new Modelos.Departamentos.DepartamentoViewModel
                                                                                     {
                                                                                         ID = d.ID,
                                                                                         idProvincia = d.idProvincia,
                                                                                         Nombre = d.Nombre
                                                                                     }).ToList();

                return departamentos;
            }

        }

       
        public Modelos.Departamentos.DepartamentoViewModel Get(int id) =>
                                   new Modelos.Departamentos.DepartamentoViewModel(dbtest.Departamentos.FirstOrDefault(x=> x.ID == id));

        

       
    }
}
