using Microsoft.AspNetCore.Mvc;
using MyProject.Catalog.Service.Dtos;

namespace MyProject.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        //Defining List for data transfer
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(),"Crochet Purse", "Handcrochet purse with cotton innser linings", 500, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Paper bead Necklace", "Beautifully handcrafted paper beads necklace for her", 200, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Wooden Comb", "Handmade wooden purse", 1500, DateTimeOffset.UtcNow),
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        {
            //Find the existing item first
            var existingItem = items.Where(item => item.Id == id).SingleOrDefault();
            if (existingItem == null)
            {
                return NotFound();
            }
            else
            {
                var updatedItem = existingItem with
                {
                    Name = updateItemDto.Name,
                    Description = updateItemDto.Description,
                    Price = updateItemDto.Price
                };

                //Find the existing item index
                var index = items.FindIndex(existingItem => existingItem.Id == id);
                items[index] = updatedItem;

                return NoContent();
            }
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            return NoContent();
        }
    }
}