using System;
using System.Collections.Generic;

namespace NewIceCream.Domain.Models;

public partial class AppUser: Model
{
    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
