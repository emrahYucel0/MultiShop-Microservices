using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries;

public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{
}
