namespace Network
{
	public interface IClientBase
	{
		int Id { get; set; }
		TCPBase Tcp { get; set; }
		UDPBase Udp { get; set; }

		void Disconnect();
	}
}
