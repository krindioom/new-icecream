using Microsoft.EntityFrameworkCore;
using NewIceCream.DAL.Repository;
using NewIceCream.Domain.JsonModels;
using NewIceCream.Domain.Models;

namespace NewIceCream.Service.Services.IceCreamBuilder;

public class IceCreamBuilderService : IIceCreamBuilderService
{
    private readonly IRepository<Icecream> _iceCreamRepository;
    private readonly IRepository<Flavor> _flavorRepository;
    private readonly IRepository<FlavorIcecream> _flavorIcecreamRepository;
    private readonly IRepository<Cone> _coneRepository;

    public IceCreamBuilderService(IRepository<Icecream> iceCreamRepository,
        IRepository<Flavor> flavorRepository,
        IRepository<Cone> coneRepository, IRepository<FlavorIcecream> flavorIcecream)
    {
        _iceCreamRepository = iceCreamRepository;
        _flavorRepository = flavorRepository;
        _coneRepository = coneRepository;
        _flavorIcecreamRepository = flavorIcecream;
    }

    public void CreateIceCream(BuildedIceCream buildedIceCream)
    {
        IEnumerable<string> flavorsName = buildedIceCream.Flavors;
        string coneName = buildedIceCream.Cone;

        Cone? cone = /*await*/ _coneRepository.GetAll().FirstOrDefault(x => x.ConeType == coneName);
        List<Flavor>? flavors = new List<Flavor>();
        FlavorIcecream? flavorIcecream;
        Icecream icecream = new()
        {
            IdCone = cone.Id,
            IdIcecreamCategory = 1,
            Price = 10 + cone.Price
        };

        foreach (var item in flavorsName)
        {
            Flavor flavor = /*await*/ _flavorRepository.GetAll().FirstOrDefault(x => x.FlavorTaste == item);
            
            flavors?.Add(flavor);

            icecream.Price += flavor.Price;
        }

        /*await*/ _iceCreamRepository.Create(icecream);

        foreach (var item in flavors)
        {
            flavorIcecream = new()
            {
                IdFlavor = item.Id,
                IdIcecream = icecream.Id
            };
            icecream.FlavorIcecreams.Add(flavorIcecream);
            _flavorIcecreamRepository.Create(flavorIcecream);
        }
    }
}
