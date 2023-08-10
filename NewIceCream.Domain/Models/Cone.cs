using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class Cone
{
    public int Id { get; set; }

    public string ConeType { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Icecream> Icecreams { get; set; } = new List<Icecream>();
}
