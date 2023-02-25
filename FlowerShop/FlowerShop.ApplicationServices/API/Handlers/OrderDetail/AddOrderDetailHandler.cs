using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
    using FlowerShop.DataAccess.CQRS.Queries.Decoration;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using FlowerShop.DataAccess.CQRS.Queries.Product;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOrderDetailHandler : IRequestHandler<AddOrderDetailRequest, AddOrderDetailResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderDetailHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderDetailResponse> Handle(AddOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetailsQuery = new GetOrderDetailsQuery();
            var getOrderDetails = await this.queryExecutor.ExecuteWithSieve(orderDetailsQuery);
            var ordersQuery = new GetOrdersQuery();
            var getOrders = await this.queryExecutor.ExecuteWithSieve(ordersQuery);
            // checking if Order with OrderId already has assigned OrderDetail with OrderDetailId and vice-versa
            // or if Order with OrderId is already in use
            if ((getOrders.Select(x => x.Id).Contains(request.OrderId) &&
                getOrderDetails.Select(x => x.OrderId).Contains(request.OrderId)) ||
                !getOrders.Select(x => x.Id).Contains(request.OrderId))
            {
                return new AddOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            var bouquetsQuery = new GetBouquetsQuery();
            // retrieving list of bouqs
            var getBouquets = await this.queryExecutor.ExecuteWithSieve(bouquetsQuery);
            // retrieving list of chosen bouqs and their IDs in form of List<Tuple<int, int>
            var bouquetsIdAndQuantity = request.BouquetsIdAndQuandity;
            // list of bouqs IDs
            var bouquetsId = bouquetsIdAndQuantity.Select(x => x.Item1);
            // retrieving list of chosen flowers based on their IDs
            var chosenBouquets = getBouquets.Where(x => bouquetsId.Contains(x.Id)).ToList();

            var decorationsQuery = new GetDecorationsQuery();
            // retrieving list of decorations
            var getDecorations = await this.queryExecutor.ExecuteWithSieve(decorationsQuery);
            // retrieving list of chosen decos and their IDs in form of List<Tuple<int, int>
            var decorationsIdAndQuantity = request.DecorationsIdAndQuandity;
            // list of decos IDs
            var decorationsId = decorationsIdAndQuantity.Select(x => x.Item1);
            // retrieving list of chosen flowers based on their IDs
            var chosenDecorations = getDecorations.Where(x => decorationsId.Contains(x.Id)).ToList();

            var productsQuery = new GetProductsQuery();
            // retrieving list of products
            var getProducts = await this.queryExecutor.ExecuteWithSieve(productsQuery);
            // retrieving list of chosen products and their IDs in form of List<Tuple<int, int>
            var productsIdAndQuantity = request.ProductsIdAndQuandity;
            // list of products IDs
            var productsId = productsIdAndQuantity.Select(x => x.Item1);
            // retrieving list of chosen products based on their IDs
            var chosenProducts = getProducts.Where(x => productsId.Contains(x.Id)).ToList();

            var orderDetail = this.mapper.Map<DataAccess.Core.Entities.OrderDetail>(request);

            var bouquetOrderDetails = new List<BouquetOrderDetail>();
            foreach(var bouquet in chosenBouquets)
            {
                bouquetOrderDetails.Add(new BouquetOrderDetail
                {
                   OrderDetail = orderDetail,
                   BouquetId = bouquet.Id,
                   // retrieving of single bouq quantity based on its ID from List<Tuple<int, int>
                   BouquetQuantity = bouquetsIdAndQuantity.Where(x => x.Item1 == bouquet.Id).Select(x => x.Item2).FirstOrDefault()
                });
            }

            var decorationOrderDetails = new List<DecorationOrderDetail>();
            foreach (var decoration in chosenDecorations)
            {
                decorationOrderDetails.Add(new DecorationOrderDetail
                {
                    OrderDetail = orderDetail,
                    DecorationId = decoration.Id,
                    // retrieving of single deco quantity based on its ID from List<Tuple<int, int>
                    DecorationQuantity = decorationsIdAndQuantity.Where(x => x.Item1 == decoration.Id).Select(x => x.Item2).FirstOrDefault()
                });
            }

            var productOrderDetails = new List<ProductOrderDetail>();
            foreach (var product in chosenProducts)
            {
                productOrderDetails.Add(new ProductOrderDetail
                {
                    OrderDetail = orderDetail,
                    ProductId = product.Id,
                    // retrieving of single product quantity based on its ID from List<Tuple<int, int>
                    ProductQuantity = productsIdAndQuantity.Where(x => x.Item1 == product.Id).Select(x => x.Item2).FirstOrDefault()
                });
            }

            var parameter = Tuple.Create(orderDetail, bouquetOrderDetails, decorationOrderDetails, productOrderDetails);

            var command = new AddOrderDetailCommand() 
            { 
                Parameter = parameter 
            };      
            var addedOrderDetail = await this.commandExecutor.Execute(command);

            var response = new AddOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetailDTO>(addedOrderDetail)
            };

            return response;
        }
    }
}