using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Core.Enums
{
    public enum UserBasketStatusEnum
    {
        [Display(Name = "Yeni Oluşturuldu")]
        NewlyCreated,

        [Display(Name = "Sipariş Verildi")]
        Ordered
    }
}
