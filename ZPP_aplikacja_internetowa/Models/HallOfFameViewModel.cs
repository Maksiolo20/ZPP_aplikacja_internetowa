namespace ZPP_aplikacja_internetowa.Models
{
    public class HallOfFameViewModel
    {
        public HallOfFameViewModel(string map, string winner, string loser, string gameStatus, string date)
        {
            Map = map;
            Winner = winner;
            Loser = loser;
            GameStatus = gameStatus;
            Date = date;
        }

        public string Map { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public string GameStatus { get; set; }
        public string Date { get; set; }

    }
}
