using System.Collections.Generic;

namespace Network
{
	public abstract class AbstractServer
	{
		public static int MaxPlayers { get; protected set; }
		public static int Port { get; protected set; }
		public static Dictionary<int, IClientBase> Clients = new Dictionary<int, IClientBase>();
		public delegate void PacketHandler(int _fromClient, Packet _packet);
		public static Dictionary<int, PacketHandler> PacketHandlers;

		public abstract void Start(int _maxPlayers, int _port);

		protected abstract void InitializeServerData();
	}
}
