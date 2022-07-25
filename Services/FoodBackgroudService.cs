using sponapp.Data;
using sponapp.DTOs;
using sponapp.Entities;
using System.Linq;
using System.Text.Json;

namespace sponapp.Services
{
    public class FoodBackgroudService : BackgroundService
    {
        public FoodBackgroudService(ILogger<FoodBackgroudService> logger, IHttpClientFactory httpClientFactory, IServiceScopeFactory serviceScopeFactory)
        {
            Logger = logger;
            _httpClientFactory = httpClientFactory;
            _serviceScopeFactory = serviceScopeFactory;
        }
        public readonly ILogger<FoodBackgroudService> Logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://api.spoonacular.com/recipes/random?apiKey=c0ef9a390ff749e59d7c9c9472c2d0b5&number=1");


                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.GetAsync("https://api.spoonacular.com/recipes/random?apiKey=a7c8c15be56344c3b4a8c9183ff67c2c&number=100");

                Dictionary<string, IEnumerable<Recipe>> openWith =
                         new Dictionary<string, IEnumerable<Recipe>>();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream =
                        await httpResponseMessage.Content.ReadAsStreamAsync();

                    var recip = await JsonSerializer.DeserializeAsync
                        <RecipList>(contentStream);
                    /*
                                        Logger.LogInformation(recip.recipes.Count().ToString());*/
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                        foreach (var item in recip.recipes)
                        {
                            await scopedServices.foods.Create(new FoodItem(item.title));
                        }


                    }


                }

                
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
