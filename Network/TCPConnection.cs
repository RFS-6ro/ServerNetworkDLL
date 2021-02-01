using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
	public abstract class TCPConnection
	{
		protected static TcpListener _tcpListener;

		protected abstract void TCPConnectCallback(IAsyncResult _result);

		protected void InitListener(IPAddress adress, int port)
		{
			_tcpListener = new TcpListener(adress, port);
			_tcpListener.Start();
			_tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);
		}
	}
}
