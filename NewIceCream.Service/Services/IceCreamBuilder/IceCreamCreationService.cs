using NewIceCream.DAL.Repository;
using NewIceCream.Domain.Models;
using NewIceCream.Domain.Response;
using NewIceCream.Domain.ViewModels;

namespace NewIceCream.Service.Services.IceCreamBuilder;

public class IceCreamCreationService: IIceCreamCreationService
{
    private readonly IRepository<Icecream> _iceCreamRepository;

	private readonly IRepository<Flavor> _flavorRepository;

	private readonly IRepository<Cone> _coneRepository;

	public IceCreamCreationService(IRepository<Icecream> iceCreamRepository, 
		IRepository<Flavor> flavorRepository, 
		IRepository<Cone> coneRepository)
	{
		_iceCreamRepository = iceCreamRepository;
		_flavorRepository = flavorRepository;
		_coneRepository = coneRepository;
	}

	public Response<IceCreamComponentsViewModel> GetComponents()
	{
		try
		{
			IceCreamComponentsViewModel viewModel = new()
			{
				Icecreams = _iceCreamRepository.GetAll().ToList(),

				Cones = _coneRepository.GetAll().ToList(),

				Flavors = _flavorRepository.GetAll().ToList()
			};

			return new Response<IceCreamComponentsViewModel>()
			{
				Data = viewModel,
				Description = "всё загрузилось",
				StatusCode = Domain.Enums.StatusCode.OK
			};
        }
		catch (Exception)
		{
            return new Response<IceCreamComponentsViewModel>()
            {
                Description = "произошла ошибка",
                StatusCode = Domain.Enums.StatusCode.InternalServiceError
            };
		}
	}
}
