using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class FlavorIcecream: Model
{
    public int IdFlavor { get; set; }

    public int IdIcecream { get; set; }

    public virtual Flavor IdFlavorNavigation { get; set; } = null!;

    public virtual Icecream IdIcecreamNavigation { get; set; } = null!;
}
