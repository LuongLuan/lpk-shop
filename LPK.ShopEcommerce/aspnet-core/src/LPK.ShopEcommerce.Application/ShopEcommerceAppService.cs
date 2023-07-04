using System;
using System.Collections.Generic;
using System.Text;
using LPK.ShopEcommerce.Localization;
using Volo.Abp.Application.Services;

namespace LPK.ShopEcommerce;

/* Inherit your application services from this class.
 */
public abstract class ShopEcommerceAppService : ApplicationService
{
    protected ShopEcommerceAppService()
    {
        LocalizationResource = typeof(ShopEcommerceResource);
    }
}
