using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        [Key]
        public int RentId { get; set; }
        public int CarId { get; set; }
        public int  CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}