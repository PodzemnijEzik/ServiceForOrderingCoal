using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public int? FkCoalType { get; set; }

    public int? FkAddres { get; set; }

    public virtual Addre? FkAddresNavigation { get; set; }

    public virtual CoalType? FkCoalTypeNavigation { get; set; }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
