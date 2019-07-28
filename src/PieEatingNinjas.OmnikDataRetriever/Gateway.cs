using PieEatingNinjas.OmnikDataRetriever.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
            => client.PostAsync(
                GetFullUrl(Constants.API_USER_ACCOUNT_VALIDATE_URL, 
                    WebUtility.UrlEncode(username), 
                    WebUtility.UrlEncode(passwd))
                , null)
            .AsApiResponse<UserData>();

        public Task<ApiResponse<PlantList>> GetPlantList()
            => EnsureUserDataSet(
                () => client.GetAsync(
                    GetFullUrl(Constants.API_PLANT_LIST_URL))
                .AsApiResponse<PlantList>());

        public Task<ApiResponse<PlantData>> GetPlantData(int plantId)
            => EnsureUserDataSet(
                () => client.GetAsync(
                    GetFullUrl(Constants.API_PLANT_DATA_URL, plantId))
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

        private string GetFullUrl(string suffix, params object[] args)
           => $"{Constants.API_BASE_URL.TrimEnd('/')}/{string.Format(suffix.TrimStart('/'), args)}";
    }
}
