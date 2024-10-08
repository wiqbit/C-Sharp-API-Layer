namespace Model.Account
{
	public class Account : Base
	{ 
		public Account()
			: base(TableName.Account)
		{
		}

		public string Name { get; set; }
	}
}