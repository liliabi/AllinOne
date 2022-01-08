namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WmiServerMemory")]
    public partial class WmiServerMemory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TicketNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seq { get; set; }

        public string Name { get; set; }

        public int? MemAttribute { get; set; }

        public long? Capacity { get; set; }

        public string Caption { get; set; }

        public int? ConfiguredClockSpeed { get; set; }

        public int? ConfiguredVoltage { get; set; }

        public string CreationClassName { get; set; }

        public int? DataWidth { get; set; }

        public string Description { get; set; }

        public string DeviceLocator { get; set; }

        public int? FormFactor { get; set; }

        public bool? HotSwappable { get; set; }

        public int? InterleaveDataDepth { get; set; }

        public int? InterleavePosition { get; set; }

        public string Manufacturer { get; set; }

        public int? MaxVoltage { get; set; }

        public int? MemoryType { get; set; }

        public int? MinVoltage { get; set; }

        public string Model { get; set; }

        public string OtherIdentifyingInfo { get; set; }

        public string PartNumber { get; set; }

        public int? PositionInRow { get; set; }

        public bool? PoweredOn { get; set; }

        public bool? Removable { get; set; }

        public bool? Replaceable { get; set; }

        public string SerialNumber { get; set; }

        public string SKU { get; set; }

        public int? SMBIOSMemoryType { get; set; }

        public int? Speed { get; set; }

        public string Status { get; set; }

        public string Tag { get; set; }

        public int? TotalWidth { get; set; }

        public int? TypeDetail { get; set; }

        public string Version { get; set; }
    }
}
