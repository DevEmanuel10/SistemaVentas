//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelos.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class lote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lote()
        {
            this.detalle_Compras = new HashSet<detalle_Compras>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_prod { get; set; }
        public string lote1 { get; set; }
        public Nullable<System.DateTime> fecha_Vencimiento { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_Compras> detalle_Compras { get; set; }
        public virtual estados estados { get; set; }
        public virtual productos productos { get; set; }
    }
}
