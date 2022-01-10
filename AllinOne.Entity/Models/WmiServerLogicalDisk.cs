namespace AllinOne.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WmiServerLogicalDisk")]
    public partial class WmiServerLogicalDisk
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TicketNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seq { get; set; }

        public int? Access { get; set; }

        public int? Availability { get; set; }

        public long? BlockSize { get; set; }

        public string Caption { get; set; }

        public bool? Compressed { get; set; }

        public int? ConfigManagerErrorCode { get; set; }

        public bool? ConfigManagerUserConfig { get; set; }

        public string CreationClassName { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public int? DriveType { get; set; }

        public bool? ErrorCleared { get; set; }

        public string ErrorDescription { get; set; }

        public string ErrorMethodology { get; set; }

        public string FileSystem { get; set; }

        public long? FreeSpace { get; set; }

        public int? LastErrorCode { get; set; }

        public int? MaximumComponentLength { get; set; }

        public int? MediaType { get; set; }

        public string Name { get; set; }

        public long? NumberOfBlocks { get; set; }

        public string PNPDeviceID { get; set; }

        public bool? PowerManagementSupported { get; set; }

        public string ProviderName { get; set; }

        public string Purpose { get; set; }

        public bool? QuotasDisabled { get; set; }

        public bool? QuotasIncomplete { get; set; }

        public bool? QuotasRebuilding { get; set; }

        public long? Size { get; set; }

        public string Status { get; set; }

        public int? StatusInfo { get; set; }

        public bool? SupportsDiskQuotas { get; set; }

        public bool? SupportsFileBasedCompression { get; set; }

        public string SystemCreationClassName { get; set; }

        public string SystemName { get; set; }

        public bool? VolumeDirty { get; set; }

        public string VolumeName { get; set; }

        public string VolumeSerialNumber { get; set; }
    }
}
