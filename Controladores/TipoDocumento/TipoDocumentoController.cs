using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.TipoDocumento
{
    public class TipoDocumentoController
    {
        public List<Modelos.TipoDocumento.TipoDocumentoViewModel> getTipoDocumento()
        {
            Modelos.Entity.DB_4BitsEntities db = new Modelos.Entity.DB_4BitsEntities();

            using (db)
            {
                List<Modelos.TipoDocumento.TipoDocumentoViewModel> tipodoc = (from t in db.tipo_Doc
                                                                              select new Modelos.TipoDocumento.TipoDocumentoViewModel
                                                                              {
                                                                                  id = t.id,
                                                                                  nombre = t.nombre,
                                                                                  id_estado = t.id_estado
                                                                              }).ToList();
                return tipodoc;

            }

        }

    }
}
