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
    
    public partial class compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public compras()
        {
            this.detalle_Compras = new HashSet<detalle_Compras>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string observacion { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual estados estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_Compras> detalle_Compras { get; set; }
    }
}
