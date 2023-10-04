using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelClient.Models
{
	public class Account
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
