using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Estados
{
    public class EstadosViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public virtual ICollection<Modelos.Cliente.ClienteViewModel> Clientes { get; set; }

        public EstadosViewModel()
        {

        }


    }
}
