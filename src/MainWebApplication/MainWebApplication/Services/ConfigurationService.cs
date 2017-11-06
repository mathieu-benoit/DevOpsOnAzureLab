using Microsoft.Extensions.Configuration;

namespace MainWebApplication.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetRandomAdditionUrl()
        {
            return _configuration["MainWebApplication:RandomAdditionApiUrl"];
        }

        public bool IsRandomAdditionEnable()
        {
            return string.Compare(_configuration["MainWebApplication:EnableRandomAdditionFeature"], "true", true) == 0;
        }
    }
}
