using System;
using System.Collections.Generic;
using Network;
using TexasHoldem.Logic.Cards;

namespace PokerSynchronisation
{
	public static class GameServerSends
	{
		public enum GameServerToLobbyPackets
		{
			Welcome = 1,

			PlayerConnect = 11,
			PlayerDisconnect = 12,
			PlayerTurn = 13,
		}

		public static void Welcome(int id, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)GameServerToLobbyPackets.Welcome))
			{
				packet.Write(id);

				sendHandler(id, packet);
			}
		}

		public static void PlayerConnect(int id, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)GameServerToLobbyPackets.PlayerConnect))
			{
				packet.Write(id);

				sendHandler(id, packet);
			}
		}

		public static void PlayerDisconnect(int id, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)GameServerToLobbyPackets.PlayerDisconnect))
			{
				packet.Write(id);

				sendHandler(id, packet);
			}
		}

		public static void PlayerTurn(int id, Action<int, Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)GameServerToLobbyPackets.PlayerTurn))
			{
				packet.Write(id);

				sendHandler(id, packet);
			}
		}
	}

	public static class LobbySends
	{
		public enum LobbyPacketsToGameServer
		{
			WelcomeReceived = 1,

			TimerEvent = 11,
			TurnApprovance = 12,
			PlayerStateAtStartOfRound = 13,
			StartTurn = 14,
			ShowBank = 15,
			ConnectionToLobbyApprovance = 16,
			ShowMoneyLeft = 17,
			Dealer = 18,
			GiveCard = 19,
			ShowTableCard = 20,
			WinAmount = 21,
			ShowPlayerBet = 22,
			EndTurn = 23,
			CollectAllBets = 24,
			ShowAllCards = 25,
		}

		public static void WelcomeReceived(int lobbyId, string message, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.WelcomeReceived))
			{
				packet.Write(lobbyId);
				packet.Write(message);

				sendHandler(packet);
			}
		}

		public static void TimerEvent(int lobbyId, bool isDecreasing, float timeLeft, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.TimerEvent))
			{
				packet.Write(lobbyId);
				packet.Write(isDecreasing);
				packet.Write(timeLeft);

				sendHandler(packet);
			}
		}

		public static void TurnApprovance(int lobbyId, int playerId, bool result, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.TurnApprovance))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);
				packet.Write(result);

				sendHandler(packet);
			}
		}

		public static void PlayerStateAtStartOfRound(int lobbyId, int toPlayer, int money, int currentlyInPot, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.PlayerStateAtStartOfRound))
			{
				packet.Write(lobbyId);
				packet.Write(toPlayer);
				packet.Write(money);
				packet.Write(currentlyInPot);

				sendHandler(packet);
			}
		}

		public static void StartTurn(int lobbyId, int playerId, bool canRaise, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.StartTurn))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);
				packet.Write(canRaise);

				sendHandler(packet);
			}
		}

		public static void ShowBank(int lobbyId, int amount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.ShowBank))
			{
				packet.Write(lobbyId);
				packet.Write(amount);
				sendHandler(packet);
			}
		}

		public static void ConnectionToLobbyApprovance(int connectedLobbyId, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.ConnectionToLobbyApprovance))
			{
				packet.Write(connectedLobbyId);

				sendHandler(packet);
			}
		}

		public static void ShowMoneyLeft(int lobbyId, int playerId, int amount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.ShowMoneyLeft))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);
				packet.Write(amount);

				sendHandler(packet);
			}
		}

		public static void Dealer(int lobbyId, int dealerPlayerId, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.Dealer))
			{
				packet.Write(lobbyId);
				packet.Write(dealerPlayerId);

				sendHandler(packet);
			}
		}

		public static void GiveCard(int lobbyId, int playerId, int type, int suit, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.GiveCard))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);
				packet.Write(type);
				packet.Write(suit);

				sendHandler(packet);
			}
		}

		public static void ShowTableCards(int lobbyId, int[] types, int[] suits, int[] indexes, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.ShowTableCard))
			{
				packet.Write(lobbyId);

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

		public static void WinAmount(int lobbyId, int playerId, int amount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.WinAmount))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);
				packet.Write(amount);

				sendHandler(packet);
			}
		}

		public static void ShowPlayerBet(int lobbyId, int playerId, int betAmount, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.ShowPlayerBet))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);
				packet.Write(betAmount);

				sendHandler(packet);
			}
		}

		public static void EndTurn(int lobbyId, int playerId, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.EndTurn))
			{
				packet.Write(lobbyId);
				packet.Write(playerId);

				sendHandler(packet);
			}
		}

		public static void CollectAllBets(int lobbyId, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.CollectAllBets))
			{
				packet.Write(lobbyId);

				sendHandler(packet);
			}
		}

		public static void ShowAllCards(int lobbyId, List<Card> firstCards, List<Card> secondCards, List<int> playersOrderIds, Action<Packet> sendHandler)
		{
			using (Packet packet = new Packet((int)LobbyPacketsToGameServer.ShowAllCards))
			{
				packet.Write(lobbyId);

				if (firstCards.Count == secondCards.Count &&
					firstCards.Count == playersOrderIds.Count)
				{
					for (int i = 0; i < playersOrderIds.Count; i++)
					{
						packet.Write(playersOrderIds[i]);
						packet.Write((int)firstCards[i].Type);
						packet.Write((int)firstCards[i].Suit);
						packet.Write((int)secondCards[i].Type);
						packet.Write((int)secondCards[i].Suit);
					}

					sendHandler(packet);
				}
			}
		}
	}
}
