using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
	public class Database
	{
		static List<Cellulare>cellulari = new List<Cellulare>();	

		static List<Utente> DatiUtente = new List<Utente>()
		{
			new Utente("Michela", "123"),
			new Utente("Francesca", "000"),
			new Utente("Sofia","345")
		};

		public static string Login(string nome)
		{
			var utente = DatiUtente.FirstOrDefault(l => l.UserName == nome);

			if (utente != null)
			{
				return "Accesso effettuato";
			}
			else return "Dati non validi";
		}

		public static List<Cellulare>GetCellulari()
		{
			var httpClient = new HttpClient();
			var webSite = new HttpRequestMessage(HttpMethod.Get, "https://gist.githubusercontent.com/hanse/4458506/raw/a702c19d07bd7693ee75efef18502c421b565949/phones.json");
			
			var resp = httpClient.Send(webSite);	

			using(var reader = new StreamReader(resp.Content.ReadAsStream()))
			{
				var cell = reader.ReadToEnd();
				cellulari = JsonConvert.DeserializeObject<List<Cellulare>>(cell);


			}
			return cellulari;
		}
	}
}
