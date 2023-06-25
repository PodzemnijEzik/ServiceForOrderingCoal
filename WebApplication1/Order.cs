using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? FkClients { get; set; }

    public int? FkPrice { get; set; }

    public decimal Quantity { get; set; }

    public decimal FullPrice { get; set; }

    public DateOnly Date { get; set; }

    public virtual Client? FkClientsNavigation { get; set; }

    public virtual Price? FkPriceNavigation { get; set; }
}
