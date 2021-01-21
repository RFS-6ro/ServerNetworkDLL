using System;
using System.Net.Sockets;

namespace Network
{
	public interface ITCPConnection
	{
		protected static TcpListener _tcpListener;

		protected void TCPConnectCallback(IAsyncResult _result);
	}
}
