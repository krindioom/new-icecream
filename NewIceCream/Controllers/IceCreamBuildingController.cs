
using Microsoft.AspNetCore.Mvc;
using NewIceCream.Domain.JsonModels;
using NewIceCream.Service.Services.IceCreamBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewIceCream.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IceCreamBuildingController : ControllerBase
{
	private readonly IIceCreamBuilderService _iceCreamBuilderService;

	public IceCreamBuildingController(IIceCreamBuilderService iceCreamBuilderService)
	{
		_iceCreamBuilderService = iceCreamBuilderService;
	}

	[HttpPost("Build")]
	public async Task<IActionResult> Build([FromBody] BuildedIceCream icecream)
	{
		_iceCreamBuilderService.CreateIceCream(icecream);

		return Ok(icecream);
	}
}
