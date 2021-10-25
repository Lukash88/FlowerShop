using FlowerShop.DataAccess.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    public class UpdateFlowerRequest : IRequest<UpdateFlowerResponse>
    {
        public object Id { get; internal set; }
        public int FlowerId { get; init; }
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public byte LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }
    }
}
