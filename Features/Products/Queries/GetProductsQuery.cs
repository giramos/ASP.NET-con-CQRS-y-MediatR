using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Features.Products.Queries.GetProductsQuery;
// Otra forma de hacerlo
public class GetProductsQuery : IRequest<List<GetProductsQueryResponse>>
{

}
public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResponse>>
{
    private readonly MyAppDbContext _context;

    public GetProductsQueryHandler(MyAppDbContext context)
    {
        _context = context;
    }

    public Task<List<GetProductsQueryResponse>> Handle(GetProductsQuery request,
    CancellationToken cancellationToken) => _context.Products
                            .AsNoTracking()
                            .Select(s => new GetProductsQueryResponse
                            {
                                ProductId = s.ProductId,
                                Description = s.Description,
                                Price = s.Price

                            }).ToListAsync();
}

public class GetProductsQueryResponse
{
    public int ProductId { get; set; }
    public string Description { get; set; } = default!;
    public double Price { get; set; }

}