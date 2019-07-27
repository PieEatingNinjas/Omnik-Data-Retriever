using System;

namespace PieEatingNinjas.OmnikDataRetriever
{
    internal class Constants
    {
        internal const string API_BASE_URL = "https://api.omnikportal.com/v1";
        internal const string API_USER_ACCOUNT_VALIDATE_URL = "user/account_validate?user_email={0}&user_password={1}&user_type=-1";
        internal const string API_PLANT_LIST_URL = "plant/list?page=1&perpage=20&locale=en-US";
        internal const string API_PLANT_DATA_URL = "plant/data?plant_id={0}";
        internal const string API_UID_HEADER_NAME = "uid";
        internal const string API_APP_ID_HEADER_NAME = "appid";
        internal const string API_APP_KEY_HEADER_NAME = "appkey";
        internal const string API_APP_ID = "10038";
        internal const string API_APP_KEY = "Ox7yu3Eivicheinguth9ef9kohngo9oo";
        internal const string API_DEFAULT_UID = "-1";
    }
}
