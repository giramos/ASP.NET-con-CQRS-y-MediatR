using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Features.Products.Queries;

/// <summary>
/// Representa una consulta para obtener un producto.
/// </summary>
public class GetProductQuery : IRequest<GetProductQueryResponse>
{
    public int ProductId { get; set; }
}

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
{
    private readonly MyAppDbContext _context;

    public GetProductQueryHandler(MyAppDbContext context)
    {
        _context = context;
    }

    // 
    public async Task<GetProductQueryResponse> Handle(GetProductQuery request,
    CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Where(p => p.ProductId == request.ProductId)
            .Select(p => new GetProductQueryResponse
            {
                ProductId = p.ProductId,
                Description = p.Description,
                Price = p.Price
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (product == null)
        {
            // lanza  
            throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
        }

        return product;
    }
}

/// <summary>
/// Representa la respuesta para la consulta GetProductQuery.
/// </summary>
public class GetProductQueryResponse
{
    /// <summary>
    /// Obtiene o establece el ID del producto.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Obtiene o establece la descripción del producto.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Obtiene o establece el precio del producto.
    /// </summary>
    public double Price { get; set; }
}