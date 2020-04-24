using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Estados;
using Modelos.Entity;

namespace Controladores
{
    public class EstadosController
    {
        DB_4BitsEntities db = new DB_4BitsEntities();

        /// <summary>
        /// Devuelvo id buscando por nombre del Estado.
        /// Se utiliza ToUpper para asegurar correr comparacion.
        /// Verifico con el if que exista, sino lo creo
        /// </summary>
        /// <param name="estado">Nombre del Estado</param>
        /// <returns></returns>
        public int GetId(string estado)
        {
            estado = estado.ToUpper();
            if (db.estados.Any(x => x.nombre == estado))
            {
                return db.estados.FirstOrDefault(x => x.nombre.ToUpper() == estado.ToUpper()).id;
            }
            else
            {
                estados EstadoDB = new estados { nombre = estado };
                db.estados.Add(EstadoDB);
                db.SaveChanges();
                return db.estados.FirstOrDefault(x => x.nombre.ToUpper() == estado.ToUpper()).id;
            }
            
        }
    }
}
