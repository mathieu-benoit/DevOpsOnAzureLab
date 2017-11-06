using MainWebApplication.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainWebApplication.Pages
{
    public class RandomAdditionModel : PageModel
    {
        public bool IsEnabled { get; set; }
        public string ApiUrl { get; set; }

        public RandomAdditionModel(IConfigurationService configurationService)
        {
            IsEnabled = configurationService.IsRandomAdditionEnable();
            ApiUrl = configurationService.GetRandomAdditionUrl();
        }

        public void OnGet()
        {
            
        }
    }
}
