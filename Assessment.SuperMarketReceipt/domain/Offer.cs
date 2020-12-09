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

        public Offer(SpecialOfferType offerType, Product product, double offerAmount)
        {//Refatorado
            OfferType = offerType;
            OfferAmount = offerAmount;
            _product = product;
        }

        public SpecialOfferType OfferType { get; }

        //Refatorado
        public double OfferAmount { get; }
    }
}
