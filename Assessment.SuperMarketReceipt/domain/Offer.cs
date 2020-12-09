namespace Assessment.SuperMarketReceipt.domain
{
    public enum SpecialOfferType
    {
        ThreeForTwo,
        TenPercentDiscount,
        TwoForAmount,
        FiveForAmount
    }

    public class Offer
    {
        private Product _product;
        
        //refact
        public Offer(SpecialOfferType offerType, Product product, double offerAmount)
        {
            OfferType = offerType;
            OfferAmount = offerAmount;
            _product = product;
        }

        public SpecialOfferType OfferType { get; }

        //Refatorado
        public double OfferAmount { get; }
    }
}
