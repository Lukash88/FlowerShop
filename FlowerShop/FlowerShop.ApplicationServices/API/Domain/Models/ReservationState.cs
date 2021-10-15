using FlowerShop.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class ReservationState
    {
        public int Id { get; set; }
        public ReservationStateEnum ReservationStatus { get; set; }
    }
}
