using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecureWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public string Environment { get; set; } = string.Empty;
        public string SecretStatus { get; set; } = string.Empty;

        public IndexModel(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void OnGet()
        {
            Environment = _environment.EnvironmentName;
            
            // Try to read a secret (safely)
            try
            {
                var dbPassword = _configuration["DbPassword"];
                SecretStatus = !string.IsNullOrEmpty(dbPassword) ? "✅ Connected" : "❌ Not Available";
            }
            catch
            {
                SecretStatus = "❌ Error";
            }
        }
    }
}