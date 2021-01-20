using System;
using System.Net.Sockets;

namespace Network
{
	internal class TestSocket : TCPBase
	{
		public override LoggerBase _logger => throw new NotImplementedException();

		public override void DisconnectClient()
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

		protected override bool HandleReceivedData(byte[] data)
		{
			throw new NotImplementedException();
		}
	}

	internal class TestClient : IClientBase
	{
		int IClientBase.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		TCPBase IClientBase.Tcp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		UDPBase IClientBase.Udp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		void IClientBase.Disconnect()
		{
			throw new NotImplementedException();
		}
	}
}
