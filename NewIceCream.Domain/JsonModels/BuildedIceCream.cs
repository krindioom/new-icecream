using NewIceCream.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIceCream.Domain.JsonModels;

public class BuildedIceCream
{
    public List<string> Flavors { get; set; }

    public string Cone { get; set; }
}
