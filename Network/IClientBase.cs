namespace Network
{
	public interface IClientBase
	{
		public int Id { get; set; }
		public TCPBase Tcp { get; set; }

		void InitClient();
	}
}