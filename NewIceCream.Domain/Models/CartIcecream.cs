using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class CartIcecream: Model
{
    public int IdCart { get; set; }

    public int IdIcecream { get; set; }

    public virtual Cart IdCartNavigation { get; set; } = null!;

    public virtual Icecream IdIcecreamNavigation { get; set; } = null!;
}
