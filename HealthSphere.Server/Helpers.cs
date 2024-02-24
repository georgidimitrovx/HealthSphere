namespace HealthSphere.Server
{
    public static class Helpers
    {
        public enum ServiceTypes
        {
            Unidentified = -1,
            Authentication,
        }

        public static ServiceTypes GetServiceFromUrl(string url)
        {
            switch(url)
            {
                case "signIn":
                case "signUp":
                    return ServiceTypes.Authentication;
            }

            return ServiceTypes.Unidentified;
        }

        public static string GetServiceEndpoint(ServiceTypes serviceType, bool isFullPath = false)
        {
            string result = "";

            switch (serviceType)
            {
                case ServiceTypes.Authentication:
                    result += "https://localhost:7271";
                    break;
            }

            if (isFullPath)
            {
                switch (serviceType)
                {
                    case ServiceTypes.Authentication:
                        result += "/api/Authentication/";
                        break;
                }
            }

            return result;
        }
    }
}
