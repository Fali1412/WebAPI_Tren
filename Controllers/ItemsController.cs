using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ItemDtos> GetItems()
        {
            var items = _repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDtos> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null)
            {
                return NotFound(); 
            }
            
            return item.AsDto();
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDtos> CreateItem(CreateItemDtos itemDtos)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDtos.Name,
                Price = itemDtos.Price,
                CreateDate = DateTimeOffset.UtcNow
            };
            
            _repository.CreateItem(item);
             
            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto());
        }
        
        //PUT /items/{id}
        [HttpPut("{id}")]

        public ActionResult UpdateItem(Guid id,UpdateItemDto itemDto)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updateItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            
            _repository.UpdateItem(updateItem);

            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }
            
            _repository.DeleteItem(id);

            return NoContent();
        }
    }
}