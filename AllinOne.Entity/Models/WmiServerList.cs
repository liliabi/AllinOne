namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WmiServerList")]
    public partial class WmiServerList
    {
        [Key]
        [StringLength(100)]
        public string SGUID { get; set; }

        [Required]
        public string ServerName { get; set; }

        [Required]
        public string ServerIP { get; set; }

        public string ServerDesc { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserPwd { get; set; }

        [Required]
        public string ServerType { get; set; }

        [Required]
        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Ver { get; set; }
    }
}
