using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syroot.Windows.IO;
using System;
using System.Net;
namespace SweeftStage2Tasks.ReadCountriesTask8
{
    public class ReadCountries
    {
        public void ReadAndWrite(string link)
        {
            
            string filePath = Path.Combine(KnownFolders.Desktop.Path, "Countries");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var countries = Task.Run(() => ReadDataAsync(link)).Result;

            foreach (CountryDto country in countries)
            {
                var path = Path.Combine(filePath, country.name.common + ".txt");
                var created = File.Create(path);
                created.Close();

                var data = WriteData(country);

                StreamWriter writer = new StreamWriter(path);
                writer.Write(data);
                writer.Close();
            }
        }

        private static async Task<List<CountryDto>> ReadDataAsync(string link)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(link);
                result.EnsureSuccessStatusCode();

                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();

                    JsonSerializer serializer = new JsonSerializer();
                    var countries = serializer.Deserialize<List<CountryDto>>(new JsonTextReader(new StringReader(response)));
                    return countries!;
                }
                else
                {
                    throw new Exception($"Failed with code {result.StatusCode}");
                }
            }
        }

        private static string WriteData(CountryDto country)
        {
            return $"Region: {country.region}\nSubregion: {country.subregion}\n" +
                $"Latitude: {country.latlng[0]}, Longitude: {country.latlng[1]}\n" +
                $"Area: {country.area}\nPopulation: {country.population}";
        }
    }
}
