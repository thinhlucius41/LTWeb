namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        public long ID_Contract { get; set; }

        [StringLength(30)]
        public string Ten { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(300)]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool hide { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }
    }
}
