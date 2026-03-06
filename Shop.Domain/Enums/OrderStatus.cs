using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Enums;

public enum OrderStatus
{
    PENDING = 0, // очікує
    PAID = 1, // оплачено
    PROCESSING = 2, // в обробці
    SHIPPED = 3, // відправлено
    DELIVERED = 4, // доставлено
    CANCELLED = 5 // скасовано
}
