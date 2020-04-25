using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Unidad
{
    public class UnidadViewModel
    {

        public int id { get; set; }
        public string nombre { get; set; }

        public UnidadViewModel()
        {

        }

        public UnidadViewModel(Modelos.Entity.unidades unidadDB)
        {
            this.id = unidadDB.id;
            this.nombre = unidadDB.nombre;
                       
        }

    }
}
