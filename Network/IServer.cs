using System.Collections.Generic;

namespace Network
{
	public interface IServer
	{
		public static int MaxPlayers { get; protected set; }
		public static int Port { get; protected set; }
		public static Dictionary<int, IClientBase> Clients = new Dictionary<int, IClientBase>();
		public delegate void PacketHandler(int _fromClient, Packet _packet);
		public static Dictionary<int, PacketHandler> packetHandlers;

		public void Start(int _maxPlayers, int _port);

		public void InitializeServerData();
	}
}
