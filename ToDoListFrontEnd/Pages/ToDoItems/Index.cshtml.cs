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

        public async Task OnGetAsync()
        {
            ToDoItems = await _httpClient.GetFromJsonAsync<IList<ToDoItem>>("ToDoItems");
        }
    }
}
