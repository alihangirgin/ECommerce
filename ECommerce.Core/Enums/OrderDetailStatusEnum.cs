using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Core.Enums
{
    public enum OrderDetailStatusEnum
    {
        [Display(Name = "Sipariş Alındı")]
        OrderHasBeen,

        [Display(Name = "Paket Hazırlanıyor")]
        Preparing,

        [Display(Name = "Paket Kargoya Verildi")]
        Shipped,

        [Display(Name = "Paket Teslim Edildi")]
        delivered

    }
}
