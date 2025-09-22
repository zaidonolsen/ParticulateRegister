using ParticulateRegister.Contracts.Enums;
using System;
using System.Collections.Generic;

namespace ParticulateRegister.Domain.Models
{
    public class ParticulateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> CropAssociations { get; set; } = new();
        public List<string> RegionAssociations { get; set; } = new();
        public List<string> SeasonalAssociations { get; set; } = new();
        public ParticulateType Type { get; set; }
        public DetectionStatus DetectionStatus { get; set; }
        public string DetectionNotes { get; set; } = string.Empty;
        public List<ParticulateHistoryDto> History { get; set; } = new();
        public string? FilePath { get; set; } // Store uploaded file path
    }
}
