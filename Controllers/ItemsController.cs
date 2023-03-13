using Microsoft.AspNetCore.Mvc;
using MyProject.Catalog.Service.Dtos;

namespace MyProject.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    class ItemsController : ControllerBase
    {
        //Defining List for data transfer
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(),"Crochet Purse", "Handcrochet purse with cotton innser linings", 500, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Paper bead Necklace", "Beautifully handcrafted paper beads necklace for her", 200, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Wooden Comb", "Handmade wooden purse", 1500, DateTimeOffset.UtcNow),
        };

        
    }
}