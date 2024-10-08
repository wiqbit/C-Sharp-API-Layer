using Data;
using Microsoft.Extensions.Configuration;
using Model;

namespace Business
{
	public abstract class Base : IBase
	{
		protected readonly IConfiguration _configuration;
		private readonly IData _data;

		protected Base(IConfiguration configuration, IData data)
		{
			_configuration = configuration;
			_data = data;
		}

		public virtual async Task<T> Add<T>(T model) where T : Model.Base
		{
			T result = default;

			result = await _data.Add<T>(model);

			if (result != null)
			{
				result = await _data.Get<T>(model.RowKey);

				result.Success = true;
			}

			return result;
		}

		public virtual async Task<bool> ChangeRowKey(Model.Base oldModel, Model.Base newModel)
		{
			bool result = false;

			result = await _data.ChangeRowKey(oldModel, newModel);

			return result;
		}

		public virtual async Task<bool> Delete(Model.Base model)
		{
			bool result = await _data.Delete(model);

			return result;
		}

		public virtual async Task<T> Get<T>(string rowKey) where T : Model.Base
		{
			T result = await _data.Get<T>(rowKey);

			if (result != null)
			{
				result.Success = true;
			}

			return result;
		}

		public virtual async Task<Query<T>> Query<T>(string filter = null) where T : Model.Base
		{
			Query<T> result = await _data.Query<T>(filter);

			result.Success = true;

			return result;
		}

		public virtual async Task<T> Update<T>(T model) where T : Model.Base
		{
			T result = await _data.Update<T>(model);

			result.Success = true;

			return result;
		}
	}
}