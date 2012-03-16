namespace MuonLab.Web.Xhtml.Example.ViewModels
{
	public class TestViewModel
	{
		public string Name { get; set; }
		public string Password { get; set; }

		public Gender? Sex { get; set; }

		public int Age { get; set; }

		public enum Gender
		{
			Male = 0,
			Female = 1
		}
	}
}