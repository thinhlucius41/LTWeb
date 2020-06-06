namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("menu")]
    public partial class menu
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        public int? idparent { get; set; }

        [Column("no.")]
        public int? no_ { get; set; }

        public bool hide { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public int? order { get; set; }

        public DateTime? dateBegin { get; set; }
    }
}
