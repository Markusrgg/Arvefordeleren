﻿using Microsoft.AspNetCore.Mvc;
using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_WebAPI.Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arvefordeleren_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IRepository<Asset> _repository;

        public AssetsController(IRepository<Asset> repository)
        {
            _repository = repository;
            _repository.Add(new Asset("Rolex", 5, "markus"));
        }

        // GET: api/assets
        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var assets = await _repository.GetAll();        
            return Ok(assets);
        }

        // GET: api/assets/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetById(Guid id)
        {
            var asset = await _repository.GetById(id);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        // POST: api/assets
        [HttpPost]
        public async Task<IActionResult> CreateAsset([FromBody] Asset asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset cannot be null.");
            }

            await _repository.Add(asset);
            return CreatedAtAction(nameof(GetAssetById), new { id = asset.Id }, asset);
        }

        // PUT: api/assets/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(Guid id, [FromBody] Asset asset)
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

        // DELETE: api/assets/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(Guid id)
        {
            var asset = await _repository.GetById(id);
            if (asset == null)
            {
                return NotFound();
            }

            await _repository.Delete(asset);
            return NoContent();
        }
    }
}