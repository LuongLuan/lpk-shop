using System;
using System.Collections.Generic;
using System.Text;

namespace LPK.ShopEcommerce.Orders
{
    public enum TransactionType
    {
        ConfirmOrder,
        StartProcessing,
        FinishOrder,
        CancelOrder
    }
}
