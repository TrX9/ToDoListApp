using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListFrontEnd.Models;

namespace ToDoListFrontEnd.Pages.ToDoItems
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ToDoApi");
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; }

        public IList<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ToDoItem = await _httpClient.GetFromJsonAsync<ToDoItem>($"ToDoItems/{id}");
            Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");

            if (ToDoItem == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
                return Page();
            }

            var response = await _httpClient.PutAsJsonAsync($"ToDoItems/{ToDoItem.Id}", ToDoItem);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the to-do item.");
                Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
