using System;
using System.Collections.Generic;

namespace PostgresDb.Models;

public partial class CoalType
{
    public int CoalTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string FullAbbreviation { get; set; } = null!;

    public short[] Size { get; set; } = null!;

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
