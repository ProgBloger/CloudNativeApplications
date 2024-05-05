using RestSharp;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using(RestClient _client = new RestClient("http://webapi:8080"))
                {
                    var request = new RestRequest("status", Method.Get);
                    var response = await _client.ExecuteAsync(request);

                    _logger.LogInformation($"RESPONSE: {response.StatusCode}, {response.Content}");
                }
                
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}