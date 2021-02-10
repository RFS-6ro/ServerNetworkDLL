using System;
using System.Collections.Generic;
using Network;

namespace PokerSynchronisation
{
	#region enums
	public static partial class ClientPacketsSend
	{
		/// <summary>Sent from client to server.</summary>
		public enum ClientPacketsToServer
		{
			WelcomeReceived = 1,        //

			template = 10,
			MakeTurn = 11,              //
			ExitLobby = 12,             //
			ConnectToLobby = 13,        //
			AskLobbiesList = 14         //
		}
	}

	public static partial class ServerPacketsSend
	{
		/// <summary>Sent from server to client.</summary>
		public enum ServerPacketsToClient
		{
			Welcome = 1,                            //sends server id to player

			template = 10,
			Dealer = 11,                            //sends dealer's server id
			GiveCard = 12,                          //
			ShowTableCard = 13,                     //
			ShowPlayerBet = 15,                //
			WinAmount = 16,                         //
			SetMoveableVariables = 17,              //
			TurnApprovance = 18,                    //
			ConnectionServerAddress = 19,           //
			StartTurn = 20,                         //
			ShowBank = 21,                          //
			ConnectionToLobbyApprovance = 22,       //
			ShowMoney = 23,                         //
			LobbyList = 24,                         //
			SendLobbyData = 25,                     //
			SendPlayerActionToLobbyPlayers = 26,    //
			CustomData = 27,                        //
			EndTurn = 28,
			ShowTimer = 29,
			CollectAllBets = 30
			//TODO:Add timer!
		}
	}
	#endregion

	public static partial class ClientPacketsSend
	{
		public static void WelcomeReceived(int id, string name, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.WelcomeReceived))
			{
				packet.Write(id);
				packet.Write(name);

				sendHandler(packet);
			}
		}

		public static void MakeTurn(int id, TurnType actionType, int raiseAmount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.MakeTurn))
			{
				packet.Write(id);
				packet.Write((int)actionType);
				packet.Write(raiseAmount);

				sendHandler(packet);
			}
		}

		public static void ExitLobby(int id, string message, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.ExitLobby))
			{
				packet.Write(id);
				packet.Write(message);

				sendHandler(packet);
			}
		}

		public static void ConnectToLobby(int id, string message, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.ConnectToLobby))
			{
				packet.Write(id);
				packet.Write(message);

				sendHandler(packet);
			}
		}

		public static void AskLobbiesList(int id, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ClientPacketsToServer.AskLobbiesList))
			{
				packet.Write(id);

				sendHandler(packet);
			}
		}
	}

	public static partial class ServerPacketsSend
	{
		public static void Welcome(int to, string message, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.Welcome))
			{
				packet.Write(to);
				packet.Write(message);

				sendHandler(to, packet);
			}
		}

		public static void ShowDealerButton(int dealerId, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.Dealer))
			{
				packet.Write(dealerId);

				sendHandler(packet);
			}
		}

		public static void GiveCards(int to, int type, int suit, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.GiveCard))
			{
				packet.Write(to);
				packet.Write(type);
				packet.Write(suit);

				sendHandler(to, packet);
			}
		}

		public static void ShowTableCard(int[] types, int[] suits, int[] indexes, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowTableCard))
			{
				packet.Write(types.Length);
				for (int i = 0; i < types.Length; i++)
				{
					int type = types[i];
					int suit = suits[i];
					int index = indexes[i];

					packet.Write(type);
					packet.Write(suit);
					packet.Write(index);
				}

				sendHandler(packet);
			}
		}

		public static void ShowPlayerBet(int playerId, int amount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowPlayerBet))
			{
				packet.Write(playerId);
				packet.Write(amount);

				sendHandler(packet);
			}
		}

		public static void GiveWinAmount(int playerId, int winAmount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.WinAmount))
			{
				packet.Write(playerId);
				packet.Write(winAmount);

				sendHandler(packet);
			}
		}

		public static void SetMoveableVariables(int to, int money, int currentlyInPot, int currentRoundBet, bool inHand, bool shouldPlayInRound, int smallBlind, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.SetMoveableVariables))
			{
				packet.Write(to);
				packet.Write(money);
				packet.Write(currentlyInPot);
				packet.Write(currentRoundBet);
				packet.Write(inHand);
				packet.Write(shouldPlayInRound);
				packet.Write(smallBlind);

				sendHandler(to, packet);
			}
		}

		public static void Approvance(int to, bool result, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.TurnApprovance))
			{
				packet.Write(to);
				packet.Write(result);

				sendHandler(to, packet);
			}
		}

		public static void ConnectToOtherServer(int to, ServerIdentifierData data, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ConnectionServerAddress))
			{
				packet.Write(to);
				packet.Write(data);

				sendHandler(to, packet);
			}
		}

		public static void StartTurn(int playerId, bool canRaise, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.StartTurn))
			{
				packet.Write(playerId);
				packet.Write(canRaise);

				sendHandler(playerId, packet);
			}
		}

		public static void StartTurn(int playerId, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.StartTurn))
			{
				packet.Write(playerId);

				sendHandler(playerId, packet);
			}
		}

		public static void EndTurn(int playerId, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.EndTurn))
			{
				packet.Write(playerId);

				sendHandler(packet);
			}
		}

		public static void ShowBank(int bank, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowBank))
			{
				packet.Write(bank);

				sendHandler(packet);
			}
		}

		public static void ConnectionToLobbyApprovance(int to, LobbyIdentifierData connectedLobbyData, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ConnectionToLobbyApprovance))
			{
				packet.Write(to);
				packet.Write(true);
				//TODO: check wtf
				packet.Write(connectedLobbyData.SmallBlind);

				sendHandler(to, packet);
			}
		}

		public static void ConnectionToLobbyApprovance(int to, string errorMessage, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ConnectionToLobbyApprovance))
			{
				packet.Write(to);
				packet.Write(false);
				packet.Write(errorMessage);

				sendHandler(to, packet);
			}
		}

		public static void ShowMoney(int playerId, int amount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.ShowMoney))
			{
				packet.Write(playerId);
				packet.Write(amount);

				sendHandler(packet);
			}
		}

		public static void SendLobbyList(int to, List<LobbyIdentifierData> lobbies, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.LobbyList))
			{
				packet.Write(to);
				packet.Write(lobbies.Count);

				foreach (var lobby in lobbies)
				{
					packet.Write(lobby.Name);
					packet.Write(lobby.ID);
					packet.Write(lobby.NumberOfPlayers);
					packet.Write(lobby.SmallBlind);
					packet.Write(lobby.BuyIn);
				}

				sendHandler(to, packet);
			}
		}

		public static void SendLobbyData(int to, List<LobbySeatData> seatDatas, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.SendLobbyData))
			{
				packet.Write(to);
				packet.Write(seatDatas.Count);

				foreach (var seat in seatDatas)
				{
					packet.Write(seat.PlayerID);
					packet.Write(seat.PlayerName);
				}

				sendHandler(to, packet);
			}
		}

		public static void SendPlayerActionToLobbyPlayers(int connectorId, string name, int offset, bool isConnecting, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.SendPlayerActionToLobbyPlayers))
			{
				packet.Write(connectorId);
				packet.Write(name);
				packet.Write(isConnecting);
				packet.Write(offset);

				sendHandler(connectorId, packet);
			}
		}

		public static void ShowTimer(int to, bool isDecreasing, int timeLeft, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.Welcome))
			{
				packet.Write(to);
				packet.Write(isDecreasing);
				packet.Write(timeLeft);

				sendHandler(packet);
			}
		}

		public static void CollectAllBets(Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.Welcome))
			{
				sendHandler(packet);
			}
		}

		/// <summary>
		/// Note that serialisation should be done in same order
		/// </summary>
		public static void SendCustomInformation<T>(int to, T data, Action<int, Packet> sendHandler) where T : BasePaketSerialisationClass, new()
		{
			using (Packet packet = new Packet((int)ServerPacketsToClient.CustomData))
			{
				packet.Write(to);
				packet.Write(data.ToByteArray());

				sendHandler(to, packet);
			}
		}
	}
}
