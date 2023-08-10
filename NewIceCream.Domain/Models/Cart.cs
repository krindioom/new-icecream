using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public virtual ICollection<CartIcecream> CartIcecreams { get; set; } = new List<CartIcecream>();

    public virtual AppUser IdUserNavigation { get; set; } = null!;
}
