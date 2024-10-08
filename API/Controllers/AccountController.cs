using API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private readonly ILogger<AccountController> _logger;
		private readonly Business.IAccount _accountBusiness;

		public AccountController(ILogger<AccountController> logger, Business.IAccount accountBusiness)
		{
			_logger = logger;
			_accountBusiness = accountBusiness;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] ViewModel.Request.AddAccount viewModel)
		{
			try
			{
				Model.Account.Account model = new Model.Account.Account()
				{
					RowKey = Guid.NewGuid().ToString(),
					Name = viewModel.Name
				};

				model = await _accountBusiness.Add(model);

				ViewModel.Response.Account result = new ViewModel.Response.Account()
				{
					Id = model.Success ? model.RowKey : null,
					Success = model.Success,
					Message = model.Message
				};

				return Json(result);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);

				return StatusCode(500);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				Model.Account.Account model = await _accountBusiness.Get<Model.Account.Account>(id);

				Base result = new Base()
				{
					Success = await _accountBusiness.Delete(model)
				};

				return Json(result);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);

				return StatusCode(500);
			}
		}
	}
}