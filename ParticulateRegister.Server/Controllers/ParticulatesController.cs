using Microsoft.AspNetCore.Mvc;
using ParticulateRegister.Domain.Interfaces;
using ParticulateRegister.Domain.Models;
using ParticulateRegister.Contracts.Models;
using AutoMapper;

namespace ParticulateRegister.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticulatesController : ControllerBase
    {
        private readonly IParticulateService _service;
        private readonly IMapper _mapper;

        public ParticulatesController(IParticulateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var particulates = await _service.GetAllAsync();
            return Ok(particulates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var particulate = await _service.GetByIdAsync(id);
            if (particulate == null) return NotFound();
            return Ok(particulate);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ParticulateCreateApiModel apiModel)
        {
            var form = Request.Form;
            var apiModel = new ParticulateCreateApiModel
            {
                Name = form["name"],
                Alias = form["alias"],
                Description = form["description"],
                CropAssociations = form.ContainsKey("cropAssociations") ? form["cropAssociations"].ToArray().ToList() : new List<string>(),
                RegionAssociations = form.ContainsKey("regionAssociations") ? form["regionAssociations"].ToArray().ToList() : new List<string>(),
                SeasonalAssociations = form.ContainsKey("seasonalAssociations") ? form["seasonalAssociations"].ToArray().ToList() : new List<string>(),
                Type = Enum.TryParse(typeof(ParticulateRegister.Contracts.Enums.ParticulateType), form["type"], out var typeVal) ? (ParticulateRegister.Contracts.Enums.ParticulateType)typeVal : 0,
                DetectionStatus = Enum.TryParse(typeof(ParticulateRegister.Contracts.Enums.DetectionStatus), form["detectionStatus"], out var statusVal) ? (ParticulateRegister.Contracts.Enums.DetectionStatus)statusVal : 0,
                DetectionNotes = form["detectionNotes"]
            };

            string? filePath = null;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var storageFolder = "C:/Users/61411/Downloads/ParticulateRegister/storage";
                    Directory.CreateDirectory(storageFolder);
                    var fileName = $"{DateTimeOffset.UtcNow:yyyyMMddHHmmssfff}{Path.GetExtension(file.FileName)}";
                    filePath = Path.Combine(storageFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            var particulate = _mapper.Map<ParticulateDto>(apiModel);
            particulate.FilePath = filePath;
            await _service.AddAsync(particulate);
            var created = (await _service.GetAllAsync()).FirstOrDefault(x => x.Name == apiModel.Name);
            return CreatedAtAction(nameof(GetById), new { id = created?.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ParticulateUpdateApiModel apiModel)
        {
            var particulate = _mapper.Map<ParticulateDto>(apiModel);
            particulate.Id = id;
            await _service.UpdateAsync(particulate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
