using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoListFrontEnd.Pages.ToDoItems
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ToDoApi");
        }

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Id = id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _httpClient.DeleteAsync($"ToDoItems/{Id}");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the to-do item.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
