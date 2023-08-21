using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class IcecreamCategory: Model
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Icecream> Icecreams { get; set; } = new List<Icecream>();
}
