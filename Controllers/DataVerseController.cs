using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class DataVerseController : ControllerBase
	{
		[HttpGet]
		public IActionResult ConnectToDataVerse()
		{
			string url = Environment.GetEnvironmentVariable("URL") ?? "Not found";
			string clientId = Environment.GetEnvironmentVariable("CLIENT_ID") ?? "";
			string clientSecret = Environment.GetEnvironmentVariable("SECRET") ?? "";
			string result = "Success";
			try
			{
				string connectionString = $@"
AuthType = ClientSecret;
Url = {url};
ClientId = {clientId}
Secret = {clientSecret}";
				var sc = new ServiceClient(connectionString);
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Ok(result);
		}
	}
}
