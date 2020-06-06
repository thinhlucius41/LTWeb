namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Key]
        public long IDnews { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool hide { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(100)]
        public string Hinh { get; set; }
    }
}
