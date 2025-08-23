using Microsoft.AspNetCore.Components;
using PrimerFrontEnd.Models;

namespace PrimerFrontEnd.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private IHttpClientFactory httpClientFactory { get; set; } = default!;
        private HttpClient httpClient;
        private static List<Users> users = new List<Users>();

        protected override async Task OnInitializedAsync()
        {
            httpClient = httpClientFactory.CreateClient("UserApi");
            await GetUsers();
        }

        private async Task GetUsers()
        {
            try
            {
                var result = await httpClient.GetAsync("/User/GetUsers");

                if(result.IsSuccessStatusCode)
                {
                    users = await result.Content.ReadFromJsonAsync<List<Users>>();
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"ocurrio un errror: {ex.Message}");
            }
        }

    }
}
