using System;
using System.Collections.Generic;
using System.Linq;
using ParticulateRegister.Domain.Models;
using ParticulateRegister.Contracts.Enums;

namespace ParticulateRegister.Data
{
    public static class ParticulateDbSeeder
    {
        public static void Seed(ParticulateDbContext context)
        {
            if (!context.Particulates.Any())
            {
                var history1 = new ParticulateHistoryDto
                {
                    Id = Guid.NewGuid(),
                    Date = DateTimeOffset.UtcNow.AddDays(-30),
                    Type = ParticulateType.Fungus,
                    Status = DetectionStatus.Detectable,
                    Notes = "Detected during spring survey."
                };

                var particulate1 = new ParticulateDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Wheat Rust",
                    Alias = "Rust",
                    Description = "A fungal disease affecting wheat crops.",
                    CropAssociations = new List<string> { "Wheat" },
                    RegionAssociations = new List<string> { "Midwest" },
                    SeasonalAssociations = new List<string> { "Spring" },
                    Type = ParticulateType.Fungus,
                    DetectionStatus = DetectionStatus.Detectable,
                    DetectionNotes = "Common in spring, easily detected.",
                    History = new List<ParticulateHistoryDto> { history1 }
                };
                history1.ParticulateId = particulate1.Id;

                var history2 = new ParticulateHistoryDto
                {
                    Id = Guid.NewGuid(),
                    Date = DateTimeOffset.UtcNow.AddDays(-10),
                    Type = ParticulateType.Pollen,
                    Status = DetectionStatus.Potential,
                    Notes = "Potential increase noted in summer."
                };

                var particulate2 = new ParticulateDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Grass Pollen",
                    Alias = "Pollen",
                    Description = "Pollen from grass, common allergen.",
                    CropAssociations = new List<string> { "Grass" },
                    RegionAssociations = new List<string> { "South" },
                    SeasonalAssociations = new List<string> { "Summer" },
                    Type = ParticulateType.Pollen,
                    DetectionStatus = DetectionStatus.Potential,
                    DetectionNotes = "Potentially high in summer.",
                    History = new List<ParticulateHistoryDto> { history2 }
                };
                history2.ParticulateId = particulate2.Id;

                context.Particulates.AddRange(particulate1, particulate2);
                context.ParticulateHistories.AddRange(history1, history2);

                context.SaveChanges();
            }
        }
    }
}
