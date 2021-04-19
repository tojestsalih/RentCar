using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int RentId { get; set; }
        public int CarId { get; set; }
        public int  CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int TotalPrice { get; set; }
        public decimal DailyPrice { get; set; }

    }
}