namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichCapDau")]
    public partial class LichCapDau
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDCapdau { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDLich { get; set; }

        [StringLength(10)]
        public string KetQua { get; set; }

        public virtual CapDau CapDau { get; set; }

        public virtual Lich Lich { get; set; }
    }
}
