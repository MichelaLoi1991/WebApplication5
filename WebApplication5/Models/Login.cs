namespace WebApplication5.Models
{
	public class LoginUtente : Utente
	{
		public bool ShowError { get; set; }

		public LoginUtente(bool showError)
		{
			ShowError = showError;
		}
	}
}
