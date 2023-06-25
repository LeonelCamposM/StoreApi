namespace StorePresentation.Shared
{
    public class GlobalVariables
    {
        private static string? userName;

        public static string GetUserName()
        {
            return userName!;
        }

        public static void SetUserName(string value)
        {
            userName = value;
        }
    }
}
