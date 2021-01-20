namespace Network
{
	public interface IClientBase
	{
		public int Id { get; set; }
		public TCPBase Tcp { get; set; }
		public UDPBase Udp { get; set; }

		protected void Disconnect();
	}
}
