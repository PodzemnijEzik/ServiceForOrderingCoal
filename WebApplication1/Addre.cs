using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class Addre
{
    public int AddresId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
