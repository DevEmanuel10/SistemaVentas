using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.TipoCliente
{
    public class TipoClienteController
    {
        public List<Modelos.TipoCliente.TipoClienteViewModel> getTipoCliente()
        {
            Modelos.Entity.DB_4BitsEntities db = new Modelos.Entity.DB_4BitsEntities();

            using (db)
            {
                List<Modelos.TipoCliente.TipoClienteViewModel> tipocl = (from t in db.tipo_Clientes
                                                                              select new Modelos.TipoCliente.TipoClienteViewModel
                                                                              {
                                                                                  id = t.id,
                                                                                  nombre = t.nombre,
                                                                                  id_estado = t.id_estado
                                                                              }).ToList();
                return tipocl;

            }

        }


    }
}
