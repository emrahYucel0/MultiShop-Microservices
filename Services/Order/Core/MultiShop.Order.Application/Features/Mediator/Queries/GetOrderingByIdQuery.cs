using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries;

public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
{
    public int Id { get; set; }

    public GetOrderingByIdQuery(int id)
    {
        Id = id;
    }
}
