using Microsoft.AspNetCore.Mvc;
using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_WebAPI.Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arvefordeleren_WebAPI.Controllers
{
    //Angiv routing for API-endpoints 
    [Route("api/aktiver")]
    [ApiController]
    public class AssetController : ControllerBase 
    {
        //et privat felt af typen IRepository<Asset> 
        private readonly IRepository<Asset> _repository;


        //Konstruktør for AssetController klassen 
        public AssetController(IRepository<Asset> repository)
        {
            _repository = repository;
        }

        // GET: api/asset - endpoint til at hente alle aktiver 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _repository.GetAll();        
            return Ok(assets);
        }

        // GET: api/asset/{id} - hente et enkelt aktiv baseret på id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var asset = await _repository.GetById(id);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        // POST: api/asset - endpoint til at oprette et aktiv 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Asset asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset cannot be null.");
            }

            await _repository.Add(asset);
            return CreatedAtAction(nameof(GetById), new { id = asset.Id }, asset);
        }

        // PUT: api/asset/{id} - endpoint til at opdatere eksisterende aktiv 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest("Asset ID mismatch.");
            }

            var existingAsset = await _repository.GetById(id);
            if (existingAsset == null)
            {
                return NotFound();
            }

            await _repository.Update(asset);
            return NoContent();
        }

        // DELETE: api/asset/{id} - endpoint til at slette et aktiv baseret på id. 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var asset = await _repository.GetById(id);
            if (asset == null)
            {
                return NotFound();//HTTP 404 not found 
            }

            await _repository.Delete(id);
            return NoContent();//returnerer en HTTP 204 no content 
        }
    }
}