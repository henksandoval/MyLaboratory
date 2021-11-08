namespace NetCoreExamples.NewFeatures._6
{
    using System;
    using System.Net.Http;

    public class ExceptionFilters : IRunnable
    {
        public void Run()
        {
            HttpClient httpClient = new HttpClient();
            System.Threading.Tasks.Task<string> streamTask = httpClient.GetStringAsync("https://www.microsoft.com");

            try
            {
                string data = streamTask.GetAwaiter().GetResult();
            }
            catch (Exception e) when (e.LogException())
            {
                //This will be never reached unless LogException 
                //extension method returns TRUE
                throw;
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("404"))
            {
                throw;
            }

        }
    }

    public static class ExceptionExtensions
    {
        public static bool LogException(this Exception ex)
        {
            Console.Error.WriteLine($"Exceptions happen: {ex.Message}");
            return true;
        }
    }

}
