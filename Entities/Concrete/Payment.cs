using Core.Entities;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int PaymentId { get; set; }
        public string CardHoldersName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string CardCVV { get; set; }
        public int PaymentAmount { get; set; }
        
    }
}