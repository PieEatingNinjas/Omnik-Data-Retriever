using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PieEatingNinjas.OmnikDataRetriever
{
    public class Gateway
    {
        readonly HttpClient client;

        UserData userData;

        public Gateway()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add(Constants.API_UID_HEADER_NAME, Constants.API_DEFAULT_UID);
            client.DefaultRequestHeaders.Add(Constants.API_APP_ID_HEADER_NAME, Constants.API_APP_ID);
            client.DefaultRequestHeaders.Add(Constants.API_APP_KEY_HEADER_NAME, Constants.API_APP_KEY);
        }

        public Task<ApiResponse<UserData>> Login(string username, string passwd)
        {
            username = HttpUtility.UrlEncode(username);
            passwd = HttpUtility.UrlEncode(passwd);
            string url = GetFullUrl(string.Format(Constants.API_USER_ACCOUNT_VALIDATE_URL, username, passwd));

            return client.PostAsync(url, null).AsApiResponse<UserData>();
        }

        public Task<ApiResponse<PlantList>> GetPlantList()
            => EnsureUserDataSet(
                () => client.GetAsync(
                    GetFullUrl(Constants.API_PLANT_LIST_URL))
                .AsApiResponse<PlantList>());

        public Task<ApiResponse<PlantData>> GetPlantData(int plantId)
            => EnsureUserDataSet(
                () => client.GetAsync(
                    GetFullUrl(string.Format(Constants.API_PLANT_DATA_URL, plantId)))
                .AsApiResponse<PlantData>());

        private Task<ApiResponse<T>> EnsureUserDataSet<T>(Func<Task<ApiResponse<T>>> func)
        {
            if (userData == null)
                throw new InvalidOperationException($"UserData is not set! Make sure to call {nameof(SetUserData)} prior to calling this method");
            return func();
        }

        public void SetUserData(UserData userData)
        {
            if (this.userData == null)
            {
                this.userData = userData;

                if (client.DefaultRequestHeaders.Contains(Constants.API_UID_HEADER_NAME))
                {
                    client.DefaultRequestHeaders.Remove(Constants.API_UID_HEADER_NAME);
                    client.DefaultRequestHeaders.Add(Constants.API_UID_HEADER_NAME, userData.UserId);
                }
            }
            else
            {
                throw new InvalidOperationException($"{nameof(this.userData)} already set!");
            }
        }

        private string GetFullUrl(string suffix)
           => $"{Constants.API_BASE_URL.TrimEnd('/')}/{suffix.TrimStart('/')}";
    }

    internal static class ClientExtensions
    {
        internal static async Task<ApiResponse<T>> AsApiResponse<T>(this Task<HttpResponseMessage> task)
        {
            var response = await task;

            var json = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<T>>(json);
        }
    }
}
