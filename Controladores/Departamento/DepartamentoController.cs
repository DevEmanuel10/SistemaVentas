using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class DepartamentoController
    {

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

        //public List<Modelos.Departamentos.DepartamentoViewModel> BuscarDepartamento(string dep)
        //{
        //    using (db)
        //    {
        //        List<Modelos.Departamentos.DepartamentoViewModel> departamentos = (from d in db.Departamentos
        //                                                                           where d.Nombre.Contains(dep)
        //                                                                           select new Modelos.Departamentos.DepartamentoViewModel
        //                                                                           {
        //                                                                               Nombre = d.Nombre
        //                                                                           }).Take(5).ToList();
        //        return departamentos;

        //    }

        //}
    }
}

//oaskhdoaishdoiahwsdaushbdijbdf