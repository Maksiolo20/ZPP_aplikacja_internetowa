namespace ZPP_aplikacja_internetowa.Models
{
    public class UnityGameResult
    {
        public string WinnersEmail { get; set; }
        public ICollection<string> PlayersEmails { get; set; }
        public int MapId { get; set; }
    }
}
