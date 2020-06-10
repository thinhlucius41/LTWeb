namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        public long idBinhLuan { get; set; }

        [StringLength(200)]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }

        public long IDuser { get; set; }

        public virtual user user { get; set; }
    }
}
