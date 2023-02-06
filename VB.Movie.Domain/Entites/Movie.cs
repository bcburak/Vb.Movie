using VB.Movie.Domain.Common;

namespace VB.Movie.Domain.Entites
{
    public class Movie : BaseEntity
    {
        public string Search_Token { get; set; }
        public string ImdbID { get; set; }
        public double Processing_Time_Ms { get; set; }
        public DateTime Timestamp { get; set; }
        public string IP_Address { get; set; }
    }
}
