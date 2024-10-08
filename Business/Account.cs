using Data;
using Microsoft.Extensions.Configuration;

namespace Business
{
	public class Account : Base, IAccount
	{
		public Account(IConfiguration configuration, IData data)
			: base(configuration, data)
		{
		}

		public override async Task<T> Add<T>(T model)
		{
			Model.Account.Account account = model as Model.Account.Account;

			if (string.IsNullOrWhiteSpace(account.Name)) {
				model.Message = "Name is required.";
			}
			else
			{
				model = await base.Add(model);
			}

			return model;
		}
	}
}