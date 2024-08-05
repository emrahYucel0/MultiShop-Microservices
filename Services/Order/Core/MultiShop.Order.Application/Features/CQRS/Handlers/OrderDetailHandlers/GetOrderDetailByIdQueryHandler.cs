﻿using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
    {
        var values = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = values.OrderDetailId,
            OrderingId = values.OrderingId,
            ProductId = values.ProductId,
            ProductAmount = values.ProductAmount,
            ProductName = values.ProductName,
            ProductPrice = values.ProductPrice,
            ProductTotalPrice = values.ProductTotalPrice,
        };
    }
}
