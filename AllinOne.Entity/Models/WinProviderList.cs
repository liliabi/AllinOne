namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WinProviderList")]
    public partial class WinProviderList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Win32Provider { get; set; }

        [StringLength(500)]
        public string Win32Link { get; set; }

        [StringLength(1)]
        public string FieldsReLoad { get; set; }

        public string CreateTableSQL { get; set; }

        public string Comment { get; set; }
    }
}
