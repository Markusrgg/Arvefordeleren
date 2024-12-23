﻿using Arvefordeleren_ClassLibrary.Enums;
using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_ClassLibrary.Services;
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
            return Ok(heirs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Heir heir)
        {
            await _repository.Add(heir);

            // Call GetAll() to retrieve the data
            var testatorResult = await _testatorController.GetAll();

            if (testatorResult is OkObjectResult okResult)
            {
                // Extract the Value (assuming it's already a list of Testators)
                var tes = okResult.Value.ToString();
                var testators = JsonConvert.DeserializeObject<List<Testator>>(tes, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                //testators = okResult.Value as IEnumerable<Testator>;

                if (testators != null)
                {
                    // Use the list of Testators as needed
                    List<Testator> result = new List<Testator>();
                    foreach (var testator in testators)
                    {
                        result.Add(testator);
                    }
                    if (heir.RelationType == RelationType.CHILD)
                    {
                        if (result.Count > 0)
                        {
                            heir.Fid = result[0].Id;

                            if (result.Count > 1)
                            {
                                heir.Mid = result[1].Id;
                            }
                        }
                    }

                    //NEXT CASE
                }
                else
                {
                    return BadRequest("Failed to deserialize testators.");
                }
            }

            var response = await _testatorController.GetAll();
            string? jsonString = (response as OkObjectResult)?.Value?.ToString();

            if (!string.IsNullOrEmpty(jsonString))
            {
                var testators = JsonConvert.DeserializeObject<List<Testator>>(jsonString, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

                //Hvis relationen er CHILD tildeles en mor og far her 
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

            var response = await _testatorController.GetAll();
            string? jsonString = (response as OkObjectResult)?.Value?.ToString();

            if (!string.IsNullOrEmpty(jsonString))
            {
                var testators = JsonConvert.DeserializeObject<List<Testator>>(jsonString, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

                if (testators != null)
                {
                    foreach (var item in testators)
                    {
                        Person p = item.Persons.FirstOrDefault(x => x.Id == id);
                        if (p != null)
                        {
                            item.Persons.Remove(p);

                            var serialized = JsonConvert.SerializeObject(item, new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.Auto, // Include type information in JSON
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Ignore circular references
                            });

                            await _testatorController.Update(serialized);
                        }
                    }
                }
            }
            return Ok();
        }
    }
}