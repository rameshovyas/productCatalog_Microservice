using MyProject.Catalog.Entities;
using MyProject.Catalog.Service.Dtos;

namespace MyProject.Catalog.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }

}