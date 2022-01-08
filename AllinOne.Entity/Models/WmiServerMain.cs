namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WmiServerMain")]
    public partial class WmiServerMain
    {
        [Key]
        [StringLength(50)]
        public string TicketNo { get; set; }

        [Required]
        [StringLength(100)]
        public string SGUID { get; set; }

        public string ServerName { get; set; }

        public string ServerIP { get; set; }

        public string ServerDesc { get; set; }

        public string UserId { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }
    }
}
