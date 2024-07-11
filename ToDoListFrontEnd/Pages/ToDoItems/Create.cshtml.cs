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

        public IList<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
                return Page();
            }

            var response = await _httpClient.PostAsJsonAsync("ToDoItems", ToDoItem);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the to-do item.");
                Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
