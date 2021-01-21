using System.Collections.Generic;

namespace Network
{
	public interface IServer
	{
		public static int MaxPlayers { get; private set; }
		public static int Port { get; private set; }
		public static Dictionary<int, IClientBase> Clients = new Dictionary<int, IClientBase>();
		public delegate void PacketHandler(int _fromClient, Packet _packet);
		public static Dictionary<int, PacketHandler> packetHandlers;

		public abstract void Start(int _maxPlayers, int _port);

		protected abstract void InitializeServerData();
	}
}
