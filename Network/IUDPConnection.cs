using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
	public interface IUDPConnection
	{
		protected static UdpClient _udpListener;

		protected void UDPReceiveCallback(IAsyncResult _result);

		public void SendUDPData(IPEndPoint _clientEndPoint, Packet _packet);

		public void InitListener(int port)
		{
			_udpListener = new UdpClient(port);
			_udpListener.BeginReceive(UDPReceiveCallback, null);
		}
	}
}
