using NewIceCream.Domain.JsonModels;

namespace NewIceCream.Service.Services.IceCreamBuilder;

public interface IIceCreamBuilderService
{
    public void CreateIceCream(BuildedIceCream buildedIceCream);
}
