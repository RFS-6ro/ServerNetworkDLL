using System;
using System.Net.Sockets;

namespace Network
{
	public abstract class TCPBase : AbstractSocket<TcpClient>
	{
		public TcpClient Socket { get; protected set; }

		protected NetworkStream _stream;
		protected Packet _receivedPacket;
		protected byte[] _receiveBuffer;

		public abstract LoggerBase _logger { get; }

		public abstract void Connect(TcpClient socket = default);

		public void SendData(Packet packet)
		{
			try
			{
				if (Socket != null)
				{
					_logger.PrintSuccess($"Writing to stream at {DateTime.Now}");
					_stream.BeginWrite(packet.ToArray(), 0, packet.Length, null, null);
				}
			}
			catch (Exception ex)
			{
				_logger.PrintError($"Error with sending data via TCP: {ex}");
			}
		}

		protected abstract void HandleData(int packetId, Packet packet);

		protected bool HandleReceivedData(byte[] data)
		{
			int packetLength = 0;

			_receivedPacket.SetBytes(data);

			if (_receivedPacket.UnreadLength >= 4)
			{
				// If client's received data contains a packet
				packetLength = _receivedPacket.ReadInt();
				if (packetLength <= 0)
				{
					// If packet contains no data
					return true; // Reset _receivedPacket instance to allow it to be reused
				}
			}

			while (packetLength > 0 && packetLength <= _receivedPacket.UnreadLength)
			{
				// While packet contains data AND packet data length doesn't exceed the length of the packet we're reading
				byte[] packetBytes = _receivedPacket.ReadBytes(packetLength);
				IThreadManager.ExecuteOnMainThread(() =>
				{
					using (Packet packet = new Packet(packetBytes))
					{
						Console.WriteLine("packet = " + packet.ToString());
						int packetId = packet.ReadInt();

						HandleData(packetId, packet); // Call appropriate method to handle the packet
													  //IServer.PacketHandlers[packetId](_id, packet);
					}
				});

				packetLength = 0; // Reset packet length
				if (_receivedPacket.UnreadLength >= 4)
				{
					// If client's received data contains another packet
					packetLength = _receivedPacket.ReadInt();
					if (packetLength <= 0)
					{
						// If packet contains no data
						return true; // Reset _receivedPacket instance to allow it to be reused
					}
				}
			}

			if (packetLength <= 1)
			{
				return true; // Reset _receivedPacket instance to allow it to be reused
			}

			return false;
		}

		public void ReceiveCallback(IAsyncResult result)
		{
			_logger.PrintSuccess($"Receiving data {DateTime.Now}");
			try
			{
				int receivedLength = _stream.EndRead(result);
				_logger.PrintSuccess($"length = {receivedLength}");

				if (receivedLength <= 0)
				{
					DisconnectClient();

					_logger.PrintWarning("Zero bytes were received. Disconnecting...");

					return;
				}

				byte[] data = new byte[receivedLength];
				Array.Copy(_receiveBuffer, data, receivedLength);

				_logger.PrintSuccess($"start handling data at {DateTime.Now}");
				_receivedPacket.Reset(HandleReceivedData(data));

				_stream.BeginRead(_receiveBuffer, 0, NetworkSettings.DATA_BUFFER_SIZE, ReceiveCallback, null);
			}
			catch (Exception ex)
			{
				_logger.PrintError($"error with receiving data: {ex}");
				Disconnect();
			}
		}

		public abstract void Disconnect();

		protected abstract void DisconnectClient();
	}
}
