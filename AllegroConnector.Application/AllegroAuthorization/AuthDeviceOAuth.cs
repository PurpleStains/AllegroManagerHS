namespace AllegroConnector.Application.AllegroAuthorization
{
    public class AuthDeviceOAuth
    {
        public string user_code { get; set; }
        public string device_code { get; set; }
        public string expires_in { get; set; }
        public int interval { get; set; }
        public string verification_uri { get; set; }
        public string verification_uri_complete { get; set; }
    }
}
