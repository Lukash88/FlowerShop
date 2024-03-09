using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Payment;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Payment
{
    public sealed class AddOrUpdatePaymentIntentHandler : IRequestHandler<AddOrUpdatePaymentIntentRequest, AddOrUpdatePaymentIntentResponse>
    {
        private readonly IPaymentService _paymentService;

        public AddOrUpdatePaymentIntentHandler(IBasketRepository basketRepository, IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
        }

        public async Task<AddOrUpdatePaymentIntentResponse> Handle(AddOrUpdatePaymentIntentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var basket = await _paymentService.CreateOrUpdatePaymentIntent(request.BasketId);

                return new AddOrUpdatePaymentIntentResponse() { Data = basket };
            }
            catch (Exception ex)
            {
                // TODO: Log the exception
                return new AddOrUpdatePaymentIntentResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem with your basket. " + ex.Message)
                };
            }
        }
    }
}