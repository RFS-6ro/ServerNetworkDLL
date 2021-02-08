namespace PokerSynchronisation
{
	public class LobbyIdentifierData
	{
		public string Name { get; set; }

		public int NumberOfPlayers { get; set; }

		public int SmallBlind { get; set; }

		public int BuyIn { get; set; }

		public LobbyIdentifierData(string name, int numberOfPlayers, int smallBlind, int buyIn)
		{
			Name = name;
			NumberOfPlayers = numberOfPlayers;
			SmallBlind = smallBlind;
			BuyIn = buyIn;
		}
	}
}
