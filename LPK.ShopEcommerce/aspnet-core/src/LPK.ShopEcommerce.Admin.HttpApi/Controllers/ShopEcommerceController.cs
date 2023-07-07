using LPK.ShopEcommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LPK.ShopEcommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ShopEcommerceController : AbpControllerBase
{
    protected ShopEcommerceController()
    {
        LocalizationResource = typeof(ShopEcommerceResource);
    }
}
