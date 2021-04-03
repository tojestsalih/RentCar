using System.Dynamic;
using Castle.DynamicProxy.Generators.Emitters;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public bool Available { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public string VehicleType { get; set; }
        public string Transmission { get; set; }
        public decimal DailyPrice { get; set; }
    }
}