using Microsoft.AspNetCore.Mvc;
using NewIceCream.Service.Services.IceCreamBuilder;

namespace NewIceCream.Controllers;

public class IceCreamCreationController : Controller
{
	private readonly IIceCreamCreationService _iceCreamBuilderService;

    public IceCreamCreationController(IIceCreamCreationService iceCreamBuilderService)
	{
		_iceCreamBuilderService = iceCreamBuilderService;
	}

	[HttpGet]
	public IActionResult IceCreamCreation()
	{
		var data = _iceCreamBuilderService.GetComponents().Data;

		return View(data);
	}
/*
	[HttpPost]
    public IActionResult IceCreamCreation()
	{

	}*/
}

