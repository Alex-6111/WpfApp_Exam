using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Exam
{
    internal abstract class APIService
    {
        private WebClient Client { get; }
        protected APIService(string baseAddress)
        {
            Client = new WebClient();
            Client.BaseAddress = baseAddress;
        }
        protected T Get<T>(string path)
        {
            string response = Client.DownloadString(path);
            var res = JsonConvert.DeserializeObject<T>(response);
            return res;
        }
        protected IEnumerable<T> GetPages<T>(string url)
        {
            List<T> result = new List<T>();
            var nextPage = -1;
            do
            {
                var dto = Get<PageDto<T>>(nextPage == -1 ? url : $"{url}{(url.Contains("?") ? "&" : "?")}page={nextPage}");
                result.AddRange(dto.Results);

                nextPage = dto.Info.Next.GetNextPageNumber();
            }
            while (nextPage != -1);

            return result;
        }
    }
}
