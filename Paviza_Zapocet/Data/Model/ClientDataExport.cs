namespace Paviza_Zapocet.Data.Model
{
    public class ClientDataExport
    {

        public PurchaseOrderHeaders PurchaseOrderHeader { get; set; }
        public double TotalPrice { get; set; } = 0;

        public ClientDataExport(PurchaseOrderHeaders _purchaseOrderHeaders, double _totalPrice)
        {
            this.PurchaseOrderHeader = _purchaseOrderHeaders;
            this.TotalPrice = _totalPrice;
        }
    }
}
