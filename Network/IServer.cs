using System.Collections.Generic;

namespace Network
{
	public interface IServer
	{
		public static int MaxPlayers { get; protected set; }
		public static int Port { get; protected set; }
		public static Dictionary<int, IClientBase> Clients = new Dictionary<int, IClientBase>();
		public delegate void PacketHandler(int fromClient, Packet packet);
		public static Dictionary<int, PacketHandler> PacketHandlers;

		public void Start(int maxPlayers, int port);

		public void InitializeServerData();
	}
}
