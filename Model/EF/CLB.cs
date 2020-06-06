namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLB")]
    public partial class CLB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLB()
        {
            CauThus = new HashSet<CauThu>();
            CT_CD = new HashSet<CT_CD>();
        }

        [Key]
        public long IDclb { get; set; }

        [StringLength(50)]
        public string TenClb { get; set; }

        [StringLength(100)]
        public string Logo { get; set; }

        [StringLength(30)]
        public string NguoiSangLap { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NamThanhLap { get; set; }

        [StringLength(30)]
        public string ViTri { get; set; }

        [StringLength(400)]
        public string GioiThieu { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool hide { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }

        public long? IDGiai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauThu> CauThus { get; set; }

        public virtual GiaiDau GiaiDau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_CD> CT_CD { get; set; }
    }
}
