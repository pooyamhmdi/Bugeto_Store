using System.ComponentModel.DataAnnotations;

namespace Bugeto_Store.Domain.Entities.Orders
{
    public enum OrderState
    {
        [Display(Name =("درحال پردازش"))]
        Processing = 0,
        [Display(Name = ("لغو شده"))]
        Canceled = 1,
        [Display(Name = ("تحویل داده شده"))]
        Deliverd = 2,
    }
}
