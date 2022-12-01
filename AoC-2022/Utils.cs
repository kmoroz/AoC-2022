using System.Net;

namespace AoC_2022
{
    public class Utils
    {
        public static async Task<string> GetInput(int day)
        {
            var fileName = "input.txt";
            var filePath = GetRelativePath(day, fileName);

            if (!File.Exists(filePath))
            {
                var uri = new Uri("https://adventofcode.com");
                var cookies = new CookieContainer();
                cookies.Add(uri, new Cookie("session", GetCookie()));
                using var file = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                using var handler = new HttpClientHandler() { CookieContainer = cookies };
                using var client = new HttpClient(handler) { BaseAddress = uri };
                using var response = await client.GetAsync($"/2022/day/{day}/input");
                using var stream = await response.Content.ReadAsStreamAsync();
                await stream.CopyToAsync(file);
            }

            return filePath;
        }

        public static string GetRelativePath(int day, string filename)
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(assemblyPath.Remove(assemblyPath.IndexOf(@"\bin\Debug")), "0" + day.ToString(), filename);
        }

        public static string GetCookie()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "secrets");
            return File.ReadAllLines(path).First();
        }
    }
}
