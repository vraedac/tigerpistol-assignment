using System;
using System.Collections.Generic;
using System.Text;

namespace DealerLib
{
	public struct Card
	{
		public Suit Suit { get; set; }
		public Rank Rank { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is Card other)
				return other.Suit == this.Suit && other.Rank == this.Rank;

			return false;
		}

		public override int GetHashCode() => (Suit, Rank).GetHashCode();
	}
}
