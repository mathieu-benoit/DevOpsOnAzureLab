using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainWebApplication.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
            throw new System.Exception("Simulate a 500 error!");
        }
    }
}
