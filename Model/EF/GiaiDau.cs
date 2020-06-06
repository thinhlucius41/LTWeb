namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaiDau")]
    public partial class GiaiDau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaiDau()
        {
            CLBs = new HashSet<CLB>();
        }

        [Key]
        public long IDGiai { get; set; }

        [StringLength(50)]
        public string TenGD { get; set; }

        [StringLength(10)]
        public string NgayBatDau { get; set; }

        [StringLength(10)]
        public string NgayKetThuc { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool hide { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLB> CLBs { get; set; }
    }
}
