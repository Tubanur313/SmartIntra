using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SmartIntranet.Core.Extensions
{
    static public partial class ModelStateExtension
    {

        static public bool IsModelStateValid(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.ModelState.IsValid;
        }
    }
}
