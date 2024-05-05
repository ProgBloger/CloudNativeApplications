using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;
using Web.Helpers;

namespace Web.Workers
{
    public class RequestWorker : BackgroundService
    {
        private readonly RequestHelper _requestHelper;
        private readonly ILogger<RequestWorker> _logger;

        public RequestWorker(
            RequestHelper requestHelper, ILogger<RequestWorker> logger)
        {
            _requestHelper = requestHelper;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using(RestClient _client = new RestClient("http://webapi:8080"))
                    {
                        var request = new RestRequest("status", Method.Get);
                        var response = await _client.ExecuteAsync(request);
                        if( response.IsSuccessful )
                        {
                            _requestHelper.Register(response.Content);
                        }
                    }
                    
                    await Task.Delay(100, stoppingToken);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }
    }
}