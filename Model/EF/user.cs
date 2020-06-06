namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        public long IDuser { get; set; }

        [StringLength(50)]
        public string TK { get; set; }

        [StringLength(32)]
        public string MK { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        public bool hide { get; set; }

        public DateTime? dateBegin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}
