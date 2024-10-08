namespace Model.Account
{
	public class Account : Base
	{ 
		public Account()
			: base(TableName.Account2)
		{
		}

		public string Name { get; set; }
	}
}