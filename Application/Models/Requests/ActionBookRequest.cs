using Model.Entities;

namespace Esame_Enterprise.Application.Models.Requests
{
    public class ActionBookRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public virtual ICollection<string> Categories { get; set; } = new List<string>();

    }

}
