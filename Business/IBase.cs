using Model;

namespace Business
{
	public interface IBase
	{
		Task<T> Add<T>(T model) where T : Model.Base;
		Task<bool> ChangeRowKey(Model.Base oldModel, Model.Base newModel);
		Task<bool> Delete(Model.Base model);
		Task<T> Get<T>(string rowKey) where T : Model.Base;
		Task<Query<T>> Query<T>(string filter = null) where T : Model.Base;
		Task<T> Update<T>(T model) where T : Model.Base;
	}
}