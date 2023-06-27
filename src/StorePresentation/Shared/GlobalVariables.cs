namespace StorePresentation.Shared
{
    public class GlobalVariables
    {
        private static string? userName;
        private static string? userEmail;
        private static string? token;

        public static string GetUserName()
        {
            return userName!;
        }

        public static void SetUserName(string value)
        {
            userName = value;
        }

        public static string GetUserEmail()
        {
            return userEmail!;
        }

        public static void SetUserEmail(string value)
        {
            userEmail = value;
        }
        public static string GetUserToken()
        {
            return token!;
        }

        public static void SetUserToken(string value)
        {
            token = value;
        }
    }
}
