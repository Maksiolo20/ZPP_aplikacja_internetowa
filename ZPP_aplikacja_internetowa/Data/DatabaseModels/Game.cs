namespace ZPP_aplikacja_internetowa.Data.DatabaseModels
{
    public class Game
    {
        public string GameId { get; set; } = Guid.NewGuid().ToString();
        public int MapId { get; set; }
        public Map Map { get; set; }
        public ICollection<GameUser> Players { get; set; }
        public string WinnerId { get; set; }
        public int GameStatusId { get; set; }
        public GameStatus GameStatuses { get; set; }
    }
}
