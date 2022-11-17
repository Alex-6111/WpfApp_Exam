using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WpfApp_Exam
{
    /// <summary>
    /// Used to Get Information using the API from https://rickandmortyapi.com/
    /// </summary>
    public static class Search
    {
        public static async Task<Multiple<Location>> GetAllLocationsAsync(int page = 1)
        {
            return await GetAllOf<Location>("location", page);
        }

        public static async Task<Multiple<Character>> GetAllCharactersAsync(int page = 1)
        {
            return await GetAllOf<Character>("character", page);
        }

        public static async Task<Multiple<Episode>> GetAllEpisodesAsync(int page = 1)
        {
            return await GetAllOf<Episode>("episode", page);
        }

        public static async Task<Multiple<Episode>> GetEpisodeAsync(int page = 1, string episodeName = null, string episodeCode = null)
        {
            string filter = $"https://rickandmortyapi.com/api/episode/?page={page}";

            if (episodeName != null)
                filter += $"&name={episodeName}";

            if (episodeCode != null)
                filter += $"&episode={episodeCode}";

            string json = await (await ApiRequester.RequestAPIAsync(filter, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            Multiple<Episode> x = JsonConvert.DeserializeObject<Multiple<Episode>>(json);

            return x;
        }

        public static async Task<Multiple<Location>> GetLocationAsync(int page = 1, string name = null, string type = null, string dimension = null)
        {
            string filter = $"https://rickandmortyapi.com/api/location/?page={page}";

            if (name != null)
                filter += $"&name={name}";

            if (type != null)
                filter += $"&type={type}";

            if (dimension != null)
                filter += $"&dimension={dimension}";

            string json = await (await ApiRequester.RequestAPIAsync(filter, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            Multiple<Location> x = JsonConvert.DeserializeObject<Multiple<Location>>(json);

            return x;
        }

        public static async Task<Multiple<Character>> GetCharacterAsync(int page = 1, string name = null, Status status = default, string species = null, string type = null, Gender gender = default)
        {
            string filter = $"https://rickandmortyapi.com/api/character/?page={page}";

            if (name != null)
                filter += $"&name={name}";

            if (status != default)
                filter += $"&status={status}";

            if (species != null)
                filter += $"&species={species}";

            if (type != null)
                filter += $"&type={type}";

            if (gender != default)
                filter += $"&gender={gender}";

            string json = await (await ApiRequester.RequestAPIAsync(filter, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            Multiple<Character> x = JsonConvert.DeserializeObject<Multiple<Character>>(json);

            return x;
        }

        public static async Task<Episode> GetEpisodeAsync(int id)
        {
            return await GetByIdAsync<Episode>("episode", id);
        }

        public static async Task<Location> GetLocationAsync(int id)
        {
            return await GetByIdAsync<Location>("location", id);
        }

        public static async Task<Character> GetCharacterAsync(int id)
        {
            return await GetByIdAsync<Character>("character", id);
        }


        public static Multiple<Character> GetCharacter(int page = 1, string name = null, Status status = default, string species = null, string type = null, Gender gender = default)
        {
            return GetCharacterAsync(page, name, status, species, type, gender).GetAwaiter().GetResult();
        }

        public static Multiple<Location> GetLocation(int page = 1, string name = null, string type = null, string dimension = null)
        {
            return GetLocationAsync(page, name, type, dimension).GetAwaiter().GetResult();
        }

        public static Multiple<Episode> GetEpisode(int page = 1, string episodeName = null, string episodeCode = null)
        {
            return GetEpisodeAsync(page, episodeName, episodeCode).GetAwaiter().GetResult();
        }


        public static Multiple<Episode> GetAllEpisodes(int page = 1)
        {
            return GetAllEpisodesAsync(page).GetAwaiter().GetResult();
        }

        public static Multiple<Character> GetAllCharacters(int page = 1)
        {
            return GetAllCharactersAsync(page).GetAwaiter().GetResult();
        }

        public static Multiple<Location> GetAllLocations(int page = 1)
        {
            return GetAllLocationsAsync(page).GetAwaiter().GetResult();
        }


        public static Episode GetEpisode(int id)
        {
            return GetEpisodeAsync(id).GetAwaiter().GetResult();
        }

        public static Location GetLocation(int id)
        {
            return GetLocationAsync(id).GetAwaiter().GetResult();
        }

        public static Character GetCharacter(int id)
        {
            return GetCharacterAsync(id).GetAwaiter().GetResult();
        }


        public static async Task<BaseAPI> GetBaseAsync()
        {
            string json = await (await ApiRequester.RequestAPIAsync("https://rickandmortyapi.com/api/", ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseAPI>(json);
        }


        public static BaseAPI GetBase()
        {
            return GetBaseAsync().GetAwaiter().GetResult();
        }

        private static async Task<T> GetByIdAsync<T>(string name, int id) where T : class
        {
            string apireq = $"https://rickandmortyapi.com/api/{name}/{id}";

            string jsonReq = await (await ApiRequester.RequestAPIAsync(apireq, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonReq);
        }


        public static async Task<string> GetContentAsync(string url)
        {
            return await (await ApiRequester.RequestAPIAsync(url, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();
        }


        public static async Task<T> UseLink<T>(string url) where T : CanError
        {
            string json = await GetContentAsync(url);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string GetContent(string url)
        {
            return GetContentAsync(url).GetAwaiter().GetResult();
        }

        private static async Task<Multiple<T>> GetAllOf<T>(string apiName, int page) where T : class
        {
            if (page < 1)
                return null;

            string apireq = $"https://rickandmortyapi.com/api/{apiName}/?page={page}";

            string json = await (await ApiRequester.RequestAPIAsync(apireq, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            Multiple<T> x = JsonConvert.DeserializeObject<Multiple<T>>(json);
            return x;
        }
    }
}
