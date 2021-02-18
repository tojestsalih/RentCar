using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int CarId { get; set; }
        public int  UserId { get; set; }
        public int RentId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string DescriptionModel { get; set; }
        public string ModelYear { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string FirstName { get; set; }

    }
}