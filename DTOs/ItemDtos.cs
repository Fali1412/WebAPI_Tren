using System;

namespace WebAPI_Tren.DTOs
{
        public record ItemDtos
        {
            public Guid Id { get; init; }
            public string Name { get; init; }
            public decimal Price { get; init; }
            public DateTimeOffset CreateDate { get; init; }
        }
}