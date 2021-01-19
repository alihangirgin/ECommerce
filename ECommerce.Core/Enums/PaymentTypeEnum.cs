using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Core.Enums
{
    public enum PaymentTypeEnum
    {
        [Display(Name = "Kredi Kartı")]
        CreditCard,

        [Display(Name = "Havale")]
        Transfer,

        [Display(Name = "Kapıda Ödeme")]
        Door
    }
}
