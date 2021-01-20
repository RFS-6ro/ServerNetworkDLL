using System;
using Network;
using TexasHoldem.Logic;
using TexasHoldem.Logic.Players;

namespace PokerSynchronisation.PacketsSending
{
	#region enum
	//////////////////SERVER////////////////////
	/// <summary>Sent from server to client.</summary>
	public enum ServerPacketsToClient
	{
		welcome = 1,
		turnApprovance,
		spawnPlayer,
		playerPosition,
		playerRotation,

		template = 1000,
		Dealer = 1001,
		GiveCard = 1002,
		ShowTableCard = 1003,
		ShowOtherPlayerCard = 1004,
		ShowOtherPlayerBet = 1005
	}
	//////////////////CLIENT////////////////////
	/// <summary>Sent from client to server.</summary>
	public enum ClientPacketsToServer
	{
		welcomeReceived = 1,
		makeTurn,
		playerMovement,
		playerShoot,
		playerThrowItem,

		template = 1000
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
			using (Packet packet = new Packet((int)ClientPacketsToServer.makeTurn))
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
	#endregion
	/*
	#region Template
	public static partial class ClientPacketsSend
	{
		public static void Template(int id, string name, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.template))
			{
				packet.Write(id);
				packet.Write(name);

				sendHandler(packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{
		public static void Template(int to, string message, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.template))
			{
				packet.Write(to);
				packet.Write(message);

				sendHandler(to, packet);
			}
		}
	}
	#endregion
	*/
}
