using Newtonsoft.Json;
using System.Text;

namespace VB.Movie.Application.Wrappers
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
}
