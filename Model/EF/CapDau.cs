namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CapDau")]
    public partial class CapDau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CapDau()
        {
            CT_CD = new HashSet<CT_CD>();
        }

        [Key]
        public long IDcapDau { get; set; }

        [StringLength(10)]
        public string NgayDau { get; set; }

        [StringLength(4)]
        public string GioDau { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool hide { get; set; }

        [Column(TypeName = "image")]
        public byte[] order { get; set; }

        public DateTime? dateBegin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_CD> CT_CD { get; set; }
    }
}
