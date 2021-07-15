using System;

namespace WebAPI_Tren.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreateDate { get; init; }
    }
}