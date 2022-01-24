namespace AllinOne.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WinProviderStructure")]
    public partial class WinProviderStructure
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProviderField { get; set; }

        [Required]
        [StringLength(50)]
        public string ProviderType { get; set; }

        public string Comment { get; set; }
    }
}
