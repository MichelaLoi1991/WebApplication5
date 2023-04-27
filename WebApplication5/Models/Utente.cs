using System.Globalization;

namespace WebApplication5.Models
{
	public class Utente
	{
		public string UserName { get; set; }
		public string Password { get; set; }

		public Utente(string username, string password) 
		{ 
			UserName = username;	
			Password = password;	
		}
		
		public Utente() { }




	}
}
