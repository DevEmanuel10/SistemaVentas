using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Unidad
{
    public class UnidadController
    {
        Modelos.Entity.DB_4BitsEntities DB = new Modelos.Entity.DB_4BitsEntities();

        //public List<Modelos.Unidad.UnidadViewModel> GetAll2()
        //{
        //    List<Modelos.Unidad.UnidadViewModel> UnidadesVM = DB.unidades.AsEnumerable().Select(x => new Modelos.Unidad.UnidadViewModel(x)).ToList();



        //    return null;
        //}

        public List<Modelos.Unidad.UnidadViewModel> GetAll() => DB.unidades.AsEnumerable().Select(x => new Modelos.Unidad.UnidadViewModel(x)).ToList();

        public Modelos.Unidad.UnidadViewModel Get(int? id) =>
                                  new Modelos.Unidad.UnidadViewModel(DB.unidades.FirstOrDefault(x => x.id == id));



    }
}
