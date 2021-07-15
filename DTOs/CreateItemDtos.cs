using System.ComponentModel.DataAnnotations;

namespace WebAPI_Tren.DTOs
{
    public record CreateItemDtos
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}