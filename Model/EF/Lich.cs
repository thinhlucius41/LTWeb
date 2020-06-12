namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lich")]
    public partial class Lich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lich()
        {
            LichCapDaus = new HashSet<LichCapDau>();
        }

        [Key]
        public long ID_lich { get; set; }

        [StringLength(20)]
        public string NgayDau { get; set; }

        [StringLength(10)]
        public string GioDau { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool hide { get; set; }

        public DateTime? dateBegin { get; set; }

        [StringLength(10)]
        public string order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichCapDau> LichCapDaus { get; set; }
    }
}
