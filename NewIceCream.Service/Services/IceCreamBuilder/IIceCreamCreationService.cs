using NewIceCream.Domain.Response;
using NewIceCream.Domain.ViewModels;

namespace NewIceCream.Service.Services.IceCreamBuilder;

public interface IIceCreamCreationService
{
    Response<IceCreamComponentsViewModel> GetComponents();
}
