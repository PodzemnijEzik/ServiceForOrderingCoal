using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class Price
{
    public int PriceId { get; set; }

    public decimal Cost { get; set; }

    public int? FkProvider { get; set; }

    public virtual Provider? FkProviderNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
