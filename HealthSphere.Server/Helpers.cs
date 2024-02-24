namespace HealthSphere.Server
{
    public static class Helpers
    {
        public enum Services
        {
            Authentication,
        }

        public static string GetServiceEndpoint(Services service, bool isFullPath = false)
        {
            string result = "";

            switch (service)
            {
                case Services.Authentication:
                    result += "https://localhost:7231";
                    break;
            }

            if (isFullPath)
            {
                switch (service)
                {
                    case Services.Authentication:
                        result += "/api/Authentication/";
                        break;
                }
            }

            return result;
        }
    }
}
