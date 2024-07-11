using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListFrontEnd.Models;

namespace ToDoListFrontEnd.Pages.ToDoItems
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ToDoApi");
        }

        public IList<ToDoItem> ToDoItems { get; set; }
        public IList<User> Users { get; set; }
        [BindProperty]
        public ToDoItem ToDoItem { get; set; }
        public async Task OnGetAsync()
        {
            ToDoItems = await _httpClient.GetFromJsonAsync<IList<ToDoItem>>("ToDoItems");
            Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
        }

        public async Task<IActionResult> OnPostCreateAsync(ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            toDoItem.IsCompleted = false; // Default IsCompleted to false

            var response = await _httpClient.PostAsJsonAsync("ToDoItems", ToDoItem);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the to-do item.");
                Users = await _httpClient.GetFromJsonAsync<IList<User>>("Users");
                ToDoItems = await _httpClient.GetFromJsonAsync<IList<ToDoItem>>("ToDoItems");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"ToDoItems/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the to-do item.");
                return Page();
            }

            return RedirectToPage();
        }
    }
}
