//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelos.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            this.ventas = new HashSet<ventas>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_tipoCliente { get; set; }
        public Nullable<int> id_tipoDoc { get; set; }
        public Nullable<int> nro_doc { get; set; }
        public Nullable<int> id_provincia { get; set; }
        public Nullable<int> id_localidad { get; set; }
        public Nullable<int> cp { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual estados estados { get; set; }
        public virtual localidades localidades { get; set; }
        public virtual provincias provincias { get; set; }
        public virtual tipo_Clientes tipo_Clientes { get; set; }
        public virtual tipo_Doc tipo_Doc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ventas> ventas { get; set; }
    }
}
