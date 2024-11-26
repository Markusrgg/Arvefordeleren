using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_WebAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(testators);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var testator = await _repository.GetById(id);
            return Ok(testator);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testator testator)
        {
            await _repository.Add(testator);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Testator testator)
        {
            var existingTestator = await _repository.GetById(testator.Id);
            if (existingTestator == null)
            {
                return NotFound();
            }

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