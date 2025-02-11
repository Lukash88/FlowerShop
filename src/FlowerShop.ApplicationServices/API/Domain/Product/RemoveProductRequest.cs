﻿using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product;

public class RemoveProductRequest : IRequest<RemoveProductResponse>
{
    public required int ProductId { get; init; }
}