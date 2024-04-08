﻿namespace AllegroConnector.Application.AllegroAuthorization
{
    public class AuthResponse
    {
        public DateTimeOffset DateTimeStamp { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string jti { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }
}
