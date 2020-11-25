namespace SWDemo.Settings
{
    public static class ApiSettings
    {
        //
        public const string APIBase = "https://www.googleapis.com/books/";
        public const string APIVersion = "v1/";
        public const string API_URL = APIBase + APIVersion;
    }

    public static class Methods
    {
        /// <summary>
        /// Format with:
        ///     Keyword {0},
        ///     StartIndex {1},
        ///     MaxItems {2}
        /// </summary>
        public static string GetBooksByName = "volumes?q={0}&startIndex={1}&maxResults={2}";
    }
}
