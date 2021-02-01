using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Network
{
	internal class TestSocket : TCPBase
	{
		public override LoggerBase _logger => throw new NotImplementedException();

		protected override void DisconnectClient()
		{
			throw new NotImplementedException();
		}

		public override void Connect(TcpClient socket = null)
		{
		}

		public override void Disconnect()
		{
			throw new NotImplementedException();
		}

		protected override void HandleData(int packetId, Packet packet)
		{
			throw new NotImplementedException();
		}

		public override void SendData(Packet packet)
		{
			throw new NotImplementedException();
		}
	}

	internal class TestSocket2 : UDPBase
	{
		public override LoggerBase _logger => throw new NotImplementedException();

		public override void Connect(object connection)
		{
			throw new NotImplementedException();
		}

		public override void Disconnect()
		{
			throw new NotImplementedException();
		}

		public override void SendData(Packet packet)
		{
			throw new NotImplementedException();
		}

		protected override void DisconnectClient()
		{
			throw new NotImplementedException();
		}

		public override void HandleData(Packet _data)
		{
			throw new NotImplementedException();
		}
	}


	internal class TestClient : IClientBase
	{
		int IClientBase.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		TCPBase IClientBase.Tcp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		UDPBase IClientBase.Udp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Disconnect()
		{
			Pool<Thread> threadPool = new Pool<Thread>(() => new Thread(g));//new ThreadStart(g)));


			throw new NotImplementedException();
		}

		public void g()
		{
		}
	}
}
