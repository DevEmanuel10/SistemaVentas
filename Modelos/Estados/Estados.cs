using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Estados
{
    class EstadosViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public virtual ICollection<ClienteViewModel> Clientes { get; set; }
    }
}
