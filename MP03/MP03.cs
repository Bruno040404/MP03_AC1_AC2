using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            try
            {
                string issPosition = await GetIssPosition();
                Console.WriteLine($"Posición actual de la ISS: {issPosition}");

                string country = await GetCountryFromCoordinates(issPosition);
                Console.WriteLine($"País actual de la ISS: {country}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            await Task.Delay(10000);
        }
    }

    static async Task<string> GetIssPosition()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("http://api.open-notify.org/iss-now.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }

    static async Task<string> GetCountryFromCoordinates(string coordinates)
    {   
        throw new NotImplementedException();
    }
}
