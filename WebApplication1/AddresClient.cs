using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class AddresClient
{
    public int AddresClientsId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
