using System;
using Network;
using TexasHoldem.Logic;
using TexasHoldem.Logic.Players;

namespace PokerSynchronisation
{
	#region enums
	public static partial class ClientPacketsSend
	{
		/// <summary>Sent from client to server.</summary>
		public enum ClientPacketsToServer
		{
			welcomeReceived = 1,

			template = 10,
			makeTurn = 11,
			ExitLobby = 12
		}
	}

	public static partial class ServerPacketsSend
	{
		/// <summary>Sent from server to client.</summary>
		public enum ServerPacketsToClient
		{
			welcome = 1,

			template = 10,
			Dealer = 11,
			GiveCard = 12,
			ShowTableCard = 13,
			ShowOtherPlayerCard = 14,
			ShowOtherPlayerBet = 15,
			WinAmount = 16,
			CommonPokerPlayerStateSerialization = 17,
			turnApprovance = 18
		}
	}

	public static partial class ServerHandlesPackets
	{
		/// <summary>Sent from client to server.</summary>
		public enum PacketsReceivedFromClient
		{
			welcomeReceived = 1,

			template = 10,
			makeTurn = 11,
			ExitLobby = 12
		}
	}

	public static partial class ClientHandlesPackets
	{
		/// <summary>Sent from server to client.</summary>
		public enum PacketsReceivedFromServer
		{
			welcome = 1,

			template = 10,
			Dealer = 11,
			GiveCard = 12,
			ShowTableCard = 13,
			ShowOtherPlayerCard = 14,
			ShowOtherPlayerBet = 15,
			WinAmount = 16,
			CommonPokerPlayerStateSerialization = 17,
			turnApprovance = 18
		}
	}
	#endregion

	#region Welcome
	public static partial class ClientPacketsSend
	{
		public static void WelcomeReceived(int id, string name, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.welcomeReceived))
			{
				packet.Write(id);
				packet.Write(name);

				sendHandler(packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{
		public static void Welcome(int to, GameRoundType type, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.welcome))
			{
				packet.Write(to);
				packet.Write((int)type);

				sendHandler(to, packet);
			}
		}
	}
	#endregion

	#region Turn
	public static partial class ClientPacketsSend
	{
		public static void MakeTurn(int id, PlayerActionType actionType, int raiseAmount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.makeTurn))
			{
				packet.Write(id);
				packet.Write((int)actionType);
				packet.Write(raiseAmount);

				sendHandler(packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{
		public static void Approvance(int to, bool result, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.turnApprovance))
			{
				packet.Write(to);
				packet.Write(result);

				sendHandler(to, packet);
			}
		}
	}
	#endregion

	#region No Sort
	public static partial class ClientPacketsSend
	{
		public static void ExitLobby(int id, string message, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.ExitLobby))
			{
				packet.Write(id);
				packet.Write(message);

				sendHandler(packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{
		public static void ShowDealerButton(int to, int index, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.Dealer))
			{
				packet.Write(to);
				packet.Write(index);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void GiveCard(int to, int type, int suit, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.GiveCard))
			{
				packet.Write(to);
				packet.Write(type);
				packet.Write(suit);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void ShowTableCard(int to, int type, int suit, int index, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowTableCard))
			{
				packet.Write(to);
				packet.Write(type);
				packet.Write(suit);
				packet.Write(index);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void ShowOtherPlayerCard(int to, int type1, int suit1, int type2, int suit2, int index, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowOtherPlayerCard))
			{
				packet.Write(to);
				packet.Write(type1);
				packet.Write(suit1);
				packet.Write(type2);
				packet.Write(suit2);
				packet.Write(index);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void ShowOtherPlayerBet(int to, int amount, int index, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowOtherPlayerBet))
			{
				packet.Write(to);
				packet.Write(amount);
				packet.Write(index);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void ShowBank(int to, int bank, int index, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowTableCard))
			{
				packet.Write(to);
				packet.Write(bank);
				packet.Write(index);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void GiveWinAmount(int to, int bank, int index, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.WinAmount))
			{
				packet.Write(to);
				packet.Write(bank);
				packet.Write(index);

				sendHandler(to, packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{

		public static void SetMoveableVariables(int to, int money, int currentlyInPot, int currentRoundBet, bool inHand, bool shouldPlayInRound, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.CommonPokerPlayerStateSerialization))
			{
				packet.Write(to);
				packet.Write(money);
				packet.Write(currentlyInPot);
				packet.Write(currentRoundBet);
				packet.Write(inHand);
				packet.Write(shouldPlayInRound);

				sendHandler(to, packet);
			}
		}
	}
	#endregion
}
