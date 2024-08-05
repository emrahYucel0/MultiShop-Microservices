﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var values = await _repository.GetByIdAsync(command.OrderDetailId);
        values.ProductName = command.ProductName;
        values.ProductPrice = command.ProductPrice;
        values.ProductId = command.ProductId;
        values.ProductTotalPrice = command.ProductTotalPrice;
        values.ProductAmount = command.ProductAmount;
        values.OrderingId = command.OrderingId;
        await _repository.UpdateAsync(values);
    }
}
