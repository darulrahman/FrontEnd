using krediku_fe.Models.Backend;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace krediku_fe.Services
{
    public class KredikuService : IKredikuService
    {
        private IConfiguration _configuration;
        string baseUrl;
        public KredikuService(IConfiguration configuration) 
        {
            _configuration = configuration;
            baseUrl = _configuration.GetSection("BaseUrl").GetSection("krediku-be").Value;
        }
        public async Task<ApiMessage<Transaction>> AddTransaction(Transaction transaction)
        {
            ApiMessage<Transaction> result = new ApiMessage<Transaction>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync<Transaction>("/api/Transaction/AddTransaction", transaction);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Error Calling API: " + response.StatusCode.ToString());

                    string strRes = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ApiMessage<Transaction>> (strRes);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
                if (ex.InnerException != null)
                    result.message += ". InnerExc: " + ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ApiMessage<List<Location>>> GetLocations()
        {
            ApiMessage<List<Location>> result = new ApiMessage<List<Location>>();
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/api/Location/GetLocations");

                    if(!response.IsSuccessStatusCode)
                        throw new Exception("Error Calling API: " + response.StatusCode.ToString());

                    string strRes = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ApiMessage<List<Location>>>(strRes);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
                if(ex.InnerException != null)
                    result.message += ". InnerExc: "+ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ApiMessage<List<Transaction>>> GetTransactions()
        {
            ApiMessage<List<Transaction>> result = new ApiMessage<List<Transaction>>();
            try
            {
                using(var client  = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage httpRes = await client.GetAsync("/api/Transaction/GetTransactions");

                    if(!httpRes.IsSuccessStatusCode)
                        throw new Exception("Error Calling API: "+httpRes.StatusCode.ToString());
                    
                    //ApiMessage<List<Transaction>> apiRes = 
                    string strResult = await httpRes.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ApiMessage<List<Transaction>>>(strResult);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
                if(ex.InnerException != null)
                    result.message += ". InnerExc: "+ ex.InnerException.Message;
            }
            return result;
        }
    }
}
