﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.TipoCliente
{
    public class TipoClienteViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> id_estado { get; set; }

    }
}
