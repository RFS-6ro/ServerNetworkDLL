using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
	public interface ITCPConnection
	{
		protected static TcpListener _tcpListener;

		protected void TCPConnectCallback(IAsyncResult _result);

		void InitListener(IPAddress adress, int port)
		{
			_tcpListener = new TcpListener(adress, port);
			_tcpListener.Start();
			_tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);
		}
	}
}
