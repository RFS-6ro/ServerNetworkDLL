using System;
using System.Text;

namespace PokerSynchronisation
{
	public class LobbyIdentifierData
	{
		public string Name { get; set; }

		public int ID { get; set; }

		public int NumberOfPlayers { get; set; }

		public int SmallBlind { get; set; }

		public int BuyIn { get; set; }

		public void FromString(string data)
		{
			try
			{
				var variables = data.Split('|');
				Name = variables[0];
				ID = Convert.ToInt32(variables[1]);
				NumberOfPlayers = Convert.ToInt32(variables[2]);
				SmallBlind = Convert.ToInt32(variables[3]);
				BuyIn = Convert.ToInt32(variables[4]);
			}
			catch
			{
				Name = "Test lobby with args error";
				ID = 0;
				NumberOfPlayers = 0;
				SmallBlind = 0;
				BuyIn = 0;
				return;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(Name);
			builder.Append('|');
			builder.Append(ID);
			builder.Append('|');
			builder.Append(NumberOfPlayers);
			builder.Append('|');
			builder.Append(SmallBlind);
			builder.Append('|');
			builder.Append(BuyIn);
			return builder.ToString();
		}
	}
}
