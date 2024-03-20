namespace Esame_Enterprise.Application.Models.Requests
{
    public class GetBooksRequest
    {
        public int From { get; set; }
        public int Num { get; set; }
        public string OrderBy { get; set; } = "";
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? Category { get; set; }

    }
}
