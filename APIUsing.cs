using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WpfApp_Exam
{
    internal class APIUsing : APIService
    {
        public APIUsing(string baseAdress = "https://rickandmortyapi.com/")
            : base(baseAdress)
        {
        }
        public Character GetCharacter(int id)
        {
            var dto = Get<Character>($"api/character/{id}");
            return (dto);
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            var dto = GetPages<Character>("api/character/");

            return (dto);
        }

        public IEnumerable<Character> GetMultipleCharacters(int[] ids)
        {
            var dto = Get<IEnumerable<Character>>($"api/character/{string.Join(",", ids)}");

            return dto;
        }

        public IEnumerable<Character> FilterCharacters(string name = "",
            CharacterStatus? characterStatus = null,
            string species = "",
            string type = "",
            CharacterGender? gender = null)
        {
            var url = "/api/character/".BuildCharacterFilterUrl(name, characterStatus, species, type, gender);

            var dto = GetPages<Character>(url);

            return dto;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            var dto = GetPages<Location>("api/location/");

            return (dto);
        }

        public IEnumerable<Location> GetMultipleLocations(int[] ids)
        {
            var dto = Get<IEnumerable<Location>>($"api/location/{string.Join(",", ids)}");
            return dto;
        }

        public Location GetLocation(int id)
        {
            var dto = Get<Location>($"api/location/{id}");

            return dto;
        }

        public IEnumerable<Location> FilterLocations(string name = "",
            string type = "",
            string dimension = "")
        {
            var url = "/api/location/".BuildLocationFilterUrl(name, type, dimension);
            var dto = GetPages<Location>(url);
            return dto;
        }

        public IEnumerable<Episode> GetAllEpisodes()
        {
            var dto = GetPages<Episode>("api/episode/");

            return dto;
        }
        public Episode GetEpisode(int id)
        {
            var dto = Get<Episode>($"api/episode/{id}");

            return dto;
        }
        public IEnumerable<Episode> GetMultipleEpisodes(int[] ids)
        {
            var dto = Get<IEnumerable<Episode>>($"api/episode/{string.Join(",", ids)}");

            return dto;
        }

        public IEnumerable<Episode> FilterEpisodes(string name = "",
            string episode = "")
        {
            var url = "/api/episode/".BuildEpisodeFilterUrl(name, episode);

            var dto = GetPages<Episode>(url);

            return dto;
        }
    }
}
