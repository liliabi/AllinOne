namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WmiServerDisk")]
    public partial class WmiServerDisk
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TicketNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seq { get; set; }

        public int? Availability { get; set; }

        public int? BytesPerSector { get; set; }

        public string Caption { get; set; }

        public string CompressionMethod { get; set; }

        public int? ConfigManagerErrorCode { get; set; }

        public bool? ConfigManagerUserConfig { get; set; }

        public string CreationClassName { get; set; }

        public long? DefaultBlockSize { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public bool? ErrorCleared { get; set; }

        public string ErrorDescription { get; set; }

        public string ErrorMethodology { get; set; }

        public string FirmwareRevision { get; set; }

        public int? Index { get; set; }

        public string InterfaceType { get; set; }

        public int? LastErrorCode { get; set; }

        public string Manufacturer { get; set; }

        public long? MaxBlockSize { get; set; }

        public long? MaxMediaSize { get; set; }

        public bool? MediaLoaded { get; set; }

        public string MediaType { get; set; }

        public long? MinBlockSize { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public bool? NeedsCleaning { get; set; }

        public int? NumberOfMediaSupported { get; set; }

        public int? Partitions { get; set; }

        public string PNPDeviceID { get; set; }

        public bool? PowerManagementSupported { get; set; }

        public int? SCSIBus { get; set; }

        public int? SCSILogicalUnit { get; set; }

        public int? SCSIPort { get; set; }

        public int? SCSITargetId { get; set; }

        public int? SectorsPerTrack { get; set; }

        public string SerialNumber { get; set; }

        public int? Signature { get; set; }

        public long? Size { get; set; }

        public string Status { get; set; }

        public int? StatusInfo { get; set; }

        public string SystemCreationClassName { get; set; }

        public string SystemName { get; set; }

        public long? TotalCylinders { get; set; }

        public int? TotalHeads { get; set; }

        public long? TotalSectors { get; set; }

        public long? TotalTracks { get; set; }

        public int? TracksPerCylinder { get; set; }
    }
}
