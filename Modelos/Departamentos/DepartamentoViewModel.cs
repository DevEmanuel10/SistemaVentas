using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Departamentos
{
    public class DepartamentoViewModel
    {
        public int ID { get; set; }
        public int idProvincia { get; set; }
        public string Nombre { get; set; }

        public DepartamentoViewModel()
        {

        }

        public DepartamentoViewModel(Modelos.Entity.Departamentos DepartamentosDB)
        {
            this.ID = DepartamentosDB.ID;
            this.idProvincia = DepartamentosDB.idProvincia;
            this.Nombre = DepartamentosDB.Nombre;
            
        }

    }
}
