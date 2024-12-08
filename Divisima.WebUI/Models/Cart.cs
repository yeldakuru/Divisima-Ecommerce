namespace Divisima.WebUI.Models
{
	public class Cart
	{
		public int ProductID { get; set; }
		public string? ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string? ProductPicture { get; set; }
		public int Quantity { get; set; }
	}
}
