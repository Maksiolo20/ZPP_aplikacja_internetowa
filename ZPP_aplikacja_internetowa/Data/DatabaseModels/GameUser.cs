namespace ZPP_aplikacja_internetowa.Data.DatabaseModels
{
    public class GameUser
    {
        public string GameUserId { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
