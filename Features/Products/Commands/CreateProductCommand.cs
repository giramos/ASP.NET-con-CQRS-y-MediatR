using Domain;
using Infrastructure.Persistence;
using MediatR;

namespace Features.Products.Commands;

public class CreateProductCommand : IRequest
{
    public string Description { get; set; } = default!;
    public double Price { get; set; }

}

public class CreateProductCommandHandler : IRequest<CreateProductCommand>
{
    private readonly MyAppDbContext _context;

    public CreateProductCommandHandler(MyAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateProductCommand command, CancellationToken token)
    {
        var newProduct = new Product
        {
            Description = command.Description,
            Price = command.Price
        };

        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync(token);

        return Unit.Value;
    }

}