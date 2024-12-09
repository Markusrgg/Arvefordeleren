using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_WebAPI.Persistance;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Arvefordeleren_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeirController : ControllerBase
    {
        private TestatorController _testatorController;

        private readonly IRepository<Heir> _repository;

        public HeirController(IRepository<Heir> repository, TestatorController testatorController)
        {
            _repository = repository;
            _testatorController = testatorController;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var heirs = await _repository.GetAll();
            return Ok(heirs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var heirs = await _repository.GetById(id);
            var serialized = JsonConvert.SerializeObject(heirs, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto, // Include type information in JSON
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Ignore circular references
            });
            return Ok(serialized);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Heir heir)
        {
            // Step 1: Add the heir to the repository
            await _repository.Add(heir);

            // Step 2: Call GetAll() to retrieve the list of testators
            var testatorResult = await _testatorController.GetAll();

            if (testatorResult is OkObjectResult okResult)
            {
                // Deserialize the JSON string into a list of Testators
                var jsonString = okResult.Value?.ToString();
                if (!string.IsNullOrEmpty(jsonString))
                {
                    var testators = JsonConvert.DeserializeObject<List<Testator>>(jsonString, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto, // Handle inheritance
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Avoid circular references
                    });

                    if (testators != null)
                    {
                        // Step 3: Assign Fid and Mid based on relation type
                        if (heir.RelationType == RelationType.CHILD)
                        {
                            if (testators.Count > 0)
                            {
                                heir.Fid = testators[0].Id;

                                if (testators.Count > 1)
                                {
                                    heir.Mid = testators[1].Id;
                                }
                            }
                        }
                    }
                    else
                    {
                        return BadRequest("Failed to deserialize testators.");
                    }
                }
                else
                {
                    return BadRequest("No testators found in the response.");
                }
            }
            else
            {
                return BadRequest("Failed to retrieve testators.");
            }

            // Step 4: Return success response
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Heir heir)
        {
            var existingHeir = await _repository.GetById(heir.Id);
            if (existingHeir == null)
            {
                return NotFound();
            }

            existingHeir = heir;

            await _repository.Update(existingHeir);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var heir = await _repository.GetById(id);
            if (heir == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return Ok();
        }
    }
}
