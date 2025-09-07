namespace ECom.Core.DTOs;
public record ProductDto
(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    int CategoryId
);
