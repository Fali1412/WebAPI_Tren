using WebAPI_Tren.DTOs;
using WebAPI_Tren.Entities;

namespace WebAPI_Tren
{
    public static class Extensions
    {
        public static ItemDtos AsDto(this Item item)
        {
            return new ItemDtos
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreateDate = item.CreateDate
            };
        }
    }
}