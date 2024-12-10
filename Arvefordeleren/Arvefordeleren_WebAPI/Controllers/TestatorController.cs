using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_WebAPI.Persistance;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Arvefordeleren_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestatorController : ControllerBase
    {
        private readonly IRepository<Testator> _repository;

        public TestatorController(IRepository<Testator> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testators = await _repository.GetAll();
            var serialized = JsonConvert.SerializeObject(testators, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto, // Include type information in JSON
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Ignore circular references
            });

            return Ok(serialized);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var testator = await _repository.GetById(id);
            var serialized = JsonConvert.SerializeObject(testator, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto, // Include type information in JSON
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Ignore circular references
            });
            return Ok(serialized);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testator testator)
        {
            await _repository.Add(testator);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] string serializedTestator)
        {
            if (string.IsNullOrEmpty(serializedTestator))
            {
                return BadRequest("Request body is null or empty.");
            }

            // Deserialize the JSON string into the Testator object, respecting type information
            var testator = JsonConvert.DeserializeObject<Testator>(serializedTestator, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto // Handle type inheritance
            });

            if (testator == null)
            {
                return BadRequest("Deserialization failed. Invalid JSON.");
            }

            var existingTestator = await _repository.GetById(testator.Id);
            if (existingTestator == null)
            {
                return NotFound();
            }

            // Update logic
            existingTestator = testator;

            await _repository.Update(existingTestator);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var testator = await _repository.GetById(id);
            if (testator == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return Ok();
        }
    }
}