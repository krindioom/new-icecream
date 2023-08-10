using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class Flavor
{
    public int Id { get; set; }

    public string FlavorTaste { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<FlavorIcecream> FlavorIcecreams { get; set; } = new List<FlavorIcecream>();
}
