namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysSerialNumber")]
    public partial class SysSerialNumber
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Project { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SeqNoDate { get; set; }

        public long MaxSeqNo { get; set; }
    }
}
