//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Collections.Generic;
    
    public partial class RTU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RTU()
        {
            this.Measurements = new HashSet<Measurement>();
        }
    
        public int Id { get; set; }
        public string RTUId { get; set; }
        public int Location { get; set; }
    
        public virtual Location Location1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
