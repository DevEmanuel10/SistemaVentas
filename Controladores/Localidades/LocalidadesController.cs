using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Localidades
{
    public class LocalidadesController
    {
       

        public List<Modelos.Localidades.LocalidadesViewModel> getLocalidades(int id_dep)
        {
            try
            {
                Modelos.Entity.DB_4BitsEntities db = new Modelos.Entity.DB_4BitsEntities();

                using (db)
                {
                    List<Modelos.Localidades.LocalidadesViewModel> localidades = (from l in db.Localidades
                                                                                  where l.idDepartamento == id_dep
                                                                                  select new Modelos.Localidades.LocalidadesViewModel
                                                                                  {
                                                                                      ID = l.ID,
                                                                                      Nombre = l.Nombre,
                                                                                      idDepartamento = l.idDepartamento

                                                                                  }).ToList();

                    return localidades;

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
           


        }


    }
}
