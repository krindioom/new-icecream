using NewIceCream.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIceCream.Domain.ViewModels;

public class IceCreamComponentsViewModel
{
    public List<Icecream>? Icecreams { get; set; }

    public List<Cone>? Cones { get; set; }

    public List<Flavor>? Flavors { get; set; }
}
