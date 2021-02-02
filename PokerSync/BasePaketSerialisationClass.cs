namespace PokerSynchronisation
{
	public abstract class BasePaketSerialisationClass
	{
		public abstract void FromByte(byte[] bytes);

		public abstract byte[] ToByteArray();
	}
}
