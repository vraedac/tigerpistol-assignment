using System;
using System.Collections.Generic;
using System.Text;

namespace DealerLib
{
	/// <summary>
	/// Represents a single playing card.
	/// </summary>
	public struct Card
	{
		/// <summary>
		/// The card's suit.
		/// </summary>
		public Suit Suit { get; set; }

		/// <summary>
		/// The card's rank.
		/// </summary>
		public Rank Rank { get; set; }

		#region Object overrides

		public override bool Equals(object obj)
		{
			if (obj is Card other)
				return other.Suit == Suit && other.Rank == Rank;

			return false;
		}

		public override int GetHashCode() => (Suit, Rank).GetHashCode();

		#endregion Object overrides
	}
}
