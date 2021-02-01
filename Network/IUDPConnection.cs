using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
	public abstract class UDPConnection
	{
		protected static UdpClient _udpListener;

		protected abstract void UDPReceiveCallback(IAsyncResult _result);

		public abstract void SendUDPData(IPEndPoint _clientEndPoint, Packet _packet);

		public void InitListener(int port)
		{
			_udpListener = new UdpClient(port);
			_udpListener.BeginReceive(UDPReceiveCallback, null);
		}
	}
}
