using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class Icecream
{
    public int Id { get; set; }

    public int IdCone { get; set; }

    public int IdIcecreamCategory { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<CartIcecream> CartIcecreams { get; set; } = new List<CartIcecream>();

    public virtual ICollection<FlavorIcecream> FlavorIcecreams { get; set; } = new List<FlavorIcecream>();

    public virtual Cone IdConeNavigation { get; set; } = null!;

    public virtual IcecreamCategory IdIcecreamCategoryNavigation { get; set; } = null!;
}
