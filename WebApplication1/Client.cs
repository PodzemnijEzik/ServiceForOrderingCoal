using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class Client
{
    public int ClientsId { get; set; }

    public string Name { get; set; } = null!;

    public int Inn { get; set; }

    public string Phone { get; set; } = null!;

    public int? FkAddresClients { get; set; }

    public int? FkAddres { get; set; }

    public virtual AddresClient? FkAddresClientsNavigation { get; set; }

    public virtual Addre? FkAddresNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
