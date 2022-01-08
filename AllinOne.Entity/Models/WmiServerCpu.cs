﻿namespace AllinOne.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WmiServerCpu")]
    public partial class WmiServerCpu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TicketNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seq { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DeviceID { get; set; }

        public int? AddressWidth { get; set; }

        public int? Architecture { get; set; }

        public string AssetTag { get; set; }

        public int? Availability { get; set; }

        public string Caption { get; set; }

        public int? Characteristics { get; set; }

        public int? ConfigManagerErrorCode { get; set; }

        public bool? ConfigManagerUserConfig { get; set; }

        public int? CpuStatus { get; set; }

        public string CreationClassName { get; set; }

        public int? CurrentClockSpeed { get; set; }

        public int? CurrentVoltage { get; set; }

        public int? DataWidth { get; set; }

        public string Description { get; set; }

        public bool? ErrorCleared { get; set; }

        public string ErrorDescription { get; set; }

        public int? ExtClock { get; set; }

        public int? Family { get; set; }

        public int? L2CacheSize { get; set; }

        public int? L2CacheSpeed { get; set; }

        public int? L3CacheSize { get; set; }

        public int? L3CacheSpeed { get; set; }

        public int? LastErrorCode { get; set; }

        public int? Level { get; set; }

        public int? LoadPercentage { get; set; }

        public string Manufacturer { get; set; }

        public int? MaxClockSpeed { get; set; }

        public int? NumberOfCores { get; set; }

        public int? NumberOfEnabledCore { get; set; }

        public int? NumberOfLogicalProcessors { get; set; }

        public string OtherFamilyDescription { get; set; }

        public string PartNumber { get; set; }

        public string PNPDeviceID { get; set; }

        public int? PowerManagementCapabilities { get; set; }

        public bool? PowerManagementSupported { get; set; }

        public string ProcessorId { get; set; }

        public int? ProcessorType { get; set; }

        public int? Revision { get; set; }

        public string Role { get; set; }

        public bool? SecondLevelAddressTranslationExtensions { get; set; }

        public string SerialNumber { get; set; }

        public string SocketDesignation { get; set; }

        public string Status { get; set; }

        public int? StatusInfo { get; set; }

        public string Stepping { get; set; }

        public string SystemCreationClassName { get; set; }

        public string SystemName { get; set; }

        public int? ThreadCount { get; set; }

        public string UniqueId { get; set; }

        public int? UpgradeMethod { get; set; }

        public string Version { get; set; }

        public bool? VirtualizationFirmwareEnabled { get; set; }

        public bool? VMMonitorModeExtensions { get; set; }

        public int? VoltageCaps { get; set; }
    }
}
