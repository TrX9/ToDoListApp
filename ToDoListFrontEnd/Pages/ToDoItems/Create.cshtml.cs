using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListFrontEnd.Models;

namespace ToDoListFrontEnd.Pages.ToDoItems
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ToDoApi");
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClient.PostAsJsonAsync("ToDoItems", ToDoItem);

            return RedirectToPage("./Index");
        }
    }
}
