namespace NetCoreExamples.NewFeatures.CS_7
{
    using System.Net.Http;
    using System.Threading.Tasks;
	using NetCoreExamples.RunnableInterfaces;

	public class AsyncReturnTypes : IRunnableCS_7
    {
        public static string CachedData = string.Empty;
        public void Run()
        {
            string result = GetData().GetAwaiter().GetResult();
            string result2 = GetData().GetAwaiter().GetResult();
        }

        public async ValueTask<string> GetData()
        {
            if (string.IsNullOrEmpty(CachedData))
            {
                HttpClient httpClient = new HttpClient();
                string result = await httpClient.GetStringAsync("http://www.microsoft.com");

                CachedData = result;
                return result;
            }

            return CachedData;
        }
    }
}
