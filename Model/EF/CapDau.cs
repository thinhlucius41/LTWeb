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
            LichCapDaus = new HashSet<LichCapDau>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_capdau { get; set; }

        public long? IDclbNha { get; set; }

        public long? IDclbKhach { get; set; }

        public virtual CLB CLB { get; set; }

        public virtual CLB CLB1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichCapDau> LichCapDaus { get; set; }

        public string Logo;
    }
}
