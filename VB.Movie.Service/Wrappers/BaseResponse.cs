namespace VB.Movie.Application.Wrappers
{
    public class BaseResponse
    {
        public Guid Id { get; set; }

        public String Message { get; set; }

        public bool IsSuccess { get; set; } = true;
    }
}
