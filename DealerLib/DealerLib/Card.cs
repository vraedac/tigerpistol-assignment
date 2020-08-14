using System;
using System.Collections.Generic;
using System.Text;

namespace DealerLib
{
	public struct Card
	{
		public Suit Suit { get; set; }
		public int Value; // 1(A), 2, 3, 4, 5, 6, 7, 8, 9, 10, 11(J), 12(Q), 13(K)

		public override bool Equals(object obj)
		{
			if (obj is Card other)
				return other.Suit == this.Suit && other.Value == this.Value;

			return false;
		}

		public override int GetHashCode() => (Suit, Value).GetHashCode();
	}
}
