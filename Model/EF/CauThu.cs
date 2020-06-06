namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauThu")]
    public partial class CauThu
    {
        [Key]
        public int IDcauThu { get; set; }

        [StringLength(30)]
        public string TenCT { get; set; }

        [StringLength(20)]
        public string ViTri { get; set; }

        [Column(TypeName = "image")]
        public byte[] AnhCT { get; set; }

        public bool? hide { get; set; }

        public long IDclb { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }

        public virtual CLB CLB { get; set; }
    }
}
