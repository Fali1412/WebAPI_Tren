using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Tren.DTOs;
using WebAPI_Tren.Entities;
using WebAPI_Tren.Repositories;

namespace WebAPI_Tren.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository _repository;

        public ItemsController(IInMemItemsRepository repository)
        {
            this._repository = repository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDtos>> GetItemsAsync()
        {
            var items = (await _repository.GetItemsAsync())
                                            .Select(item => item.AsDto());
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDtos>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound(); 
            }
            
            return item.AsDto();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDtos>> CreateItemAsync(CreateItemDtos itemDtos)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDtos.Name,
                Price = itemDtos.Price,
                CreateDate = DateTimeOffset.UtcNow
            };
            
            await _repository.CreateItemAsync(item);
             
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id}, item.AsDto());
        }
        
        //PUT /items/{id}
        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateItemAsync(Guid id,UpdateItemDto itemDto)
        {
            var existingItem = await _repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updateItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            
            await _repository.UpdateItemAsync(updateItem);

            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await _repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }
            
            await _repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}