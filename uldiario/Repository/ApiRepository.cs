using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace ULDiario.Data.Repositories
{
    public class ApiRepository 
    {

        #region Atributos

        private string _baseUrl;
        private IHttpClientFactory _clientFactory;
        private readonly ILogger<ApiRepository> _logger;

        #endregion

        #region Construtor

        /// <summary>
        /// ApiRepository
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientFactory"></param>
        /// <param name="config"></param>
        public ApiRepository(ILogger<ApiRepository> logger, IHttpClientFactory clientFactory, IConfiguration config)
        {
            _baseUrl = config.GetSection("UrlApiLoteria").Value;
            _logger = logger;
            _clientFactory = clientFactory;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// ExecuteRequest
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ExecuteRequest(string authorization, HttpMethod method, string url, HttpContent content = null)
        {
            using (var request = new HttpRequestMessage(method, _baseUrl + url))
            {
                request.Content = content;
                using (var client = _clientFactory.CreateClient("EDocs"))
                {
                    if (!string.IsNullOrWhiteSpace(authorization))
                        client.DefaultRequestHeaders.Add("Authorization", authorization);

                    return await client.SendAsync(request);
                }
            }

        }

        #endregion
    
    }
}