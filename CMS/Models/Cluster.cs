//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cluster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cluster()
        {
            this.Client = new HashSet<Client>();
            this.Comment = new HashSet<Comment>();
            this.PriceListToCluster = new HashSet<PriceListToCluster>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid ClientTypeId { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public Nullable<System.Guid> PriceList1Id { get; set; }
        public Nullable<System.Guid> PriceList2Id { get; set; }
        public Nullable<System.Guid> PriceList3Id { get; set; }
        public Nullable<System.Guid> PriceList4Id { get; set; }
        public string InvitationId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }
        public virtual ClientType ClientType { get; set; }
        public virtual PriceList PriceList { get; set; }
        public virtual PriceList PriceList1 { get; set; }
        public virtual PriceList PriceList2 { get; set; }
        public virtual PriceList PriceList3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceListToCluster> PriceListToCluster { get; set; }
    }
}
