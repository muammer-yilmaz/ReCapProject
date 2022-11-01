using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PaymentDto : IDto
    {
        //public string CardNumber { get; set; }
        //public string ExpirationMonth { get; set; }
        //public string ExpirationYear { get; set; }
        //public string Cvv { get; set; }
        //public int CarId { get; set; }
        //public int CustomerId { get; set; }
        //public DateTime RentDate { get; set; }
        //public DateTime? ReturnDate { get; set; }
        public CreditCard Card{ get; set; }
        public Rental Rental { get; set; }
    }
}
