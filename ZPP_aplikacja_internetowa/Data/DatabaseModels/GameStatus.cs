namespace ZPP_aplikacja_internetowa.Data.DatabaseModels
{
    public class GameStatus
    {
        public int GameStatusId { get; set; }
        public string StatusName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
