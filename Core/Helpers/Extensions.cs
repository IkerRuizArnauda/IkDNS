namespace IkDNS.Core.Helpers
{
	/// <summary>
	/// Bit operations extension helpers
	/// </summary>
    public static class Extensions
    {
		public static ushort SetBits(this ushort current, int position, int length, bool bValue)
		{
			if (length <= 0 || position >= 16)
				return current;

			return SetBits(current, position, length, bValue ? (ushort)1 : (ushort)0);
		}

		public static ushort SetBits(this ushort current, int position, int length, ushort newValue)
		{
			if (length <= 0 || position >= 16)
				return current;

			int bitMask = (2 << (length - 1)) - 1;
			current &= (ushort)~(bitMask << position);
			current |= (ushort)((newValue & bitMask) << position);
			
			return current;
		}

		public static ushort GetBits(this ushort current, int position, int length)
		{
			if (length <= 0 || position >= 16)
				return 0;

			int bitMask = (2 << (length - 1)) - 1;
			return (ushort)((current >> position) & bitMask);
		}
	}
}
