using System;
using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;

namespace SharpStore.Services
{
    class BuyService : Service
    {
        public BuyService(SharpStoreContext context) : base(context)
        {
        }

        public void AddPurchase(PurchaseBindingModel purchaseViewModel)
        {
            Purchase purchase = new Purchase();
            purchase.BuyerName = purchaseViewModel.BuyerName;
            purchase.DeliveryType = (DeliveryType)Enum.Parse(typeof(DeliveryType), purchaseViewModel.DeliveryType);
            purchase.BuyerAddress = purchaseViewModel.BuyerAddress;
            purchase.BuyerPhone = purchaseViewModel.BuyerPhone;

            this.context.Purchases.Add(purchase);
            this.context.SaveChanges();
        }

        public bool IsKnifeIdValid(int knifeId)
        {
            return this.context.Knives.Find(knifeId) != null;
        }
    }
}
