namespace httpClientNunit
{

    static class HttpResponseMessageExtensions
    {
        internal static void WriteRequestToConsole(this HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            Console.Write($"{request?.Method} ");
            Console.Write($"{request?.RequestUri} ");
            Console.WriteLine($"HTTP/{request?.Version}");
        }

    }

    public class Tests
    {

        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.publicapis.org/"),
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Task hmm= GetAsync(httpClient);

           
        }

        static async Task GetAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("entries");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output:
            //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/1.1
            //   {
            //     "userId": 1,
            //     "id": 3,
            //     "title": "fugiat veniam minus",
            //     "completed": false
            //   }
        }
    }
}