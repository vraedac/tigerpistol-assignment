using System;
using System.Collections.Generic;
using System.Text;

namespace DealerLib
{
	/// <summary>
	/// Represents the rank of a card as an integer value.
	/// </summary>
	public class Rank
	{
		/// <summary>
		/// The default constructor is protected so that Ranks can only ever be created by this class, to ensure their validity.
		/// </summary>
		protected Rank() { }

		public string Name { get; private set; }
		public int Value { get; private set; }

		/// <summary>
		/// Factory to produce a card of rank "Ace".
		/// </summary>
		/// <param name="high">A bool indicating whether aces are high or low; default is low</param>
		public static Rank Ace(bool high = false) => new Rank { Name = "Ace", Value = high ? 14 : 1 };

		/// <summary>
		/// Factory to produce a card of rank 2.
		/// </summary>
		public static Rank Two() => new Rank { Name = "Two", Value = 2 };

		/// <summary>
		/// Factory to produce a card of rank 3.
		/// </summary>
		public static Rank Three() => new Rank { Name = "Three", Value = 3 };

		/// <summary>
		/// Factory to produce a card of rank 4.
		/// </summary>
		public static Rank Four() => new Rank { Name = "Four", Value = 4 };

		/// <summary>
		/// Factory to produce a card of rank 5.
		/// </summary>
		public static Rank Five() => new Rank { Name = "Five", Value = 5 };

		/// <summary>
		/// Factory to produce a card of rank 6.
		/// </summary>
		public static Rank Six() => new Rank { Name = "Six", Value = 6 };

		/// <summary>
		/// Factory to produce a card of rank 7.
		/// </summary>
		public static Rank Seven() => new Rank { Name = "Seven", Value = 7 };

		/// <summary>
		/// Factory to produce a card of rank 8.
		/// </summary>
		public static Rank Eight() => new Rank { Name = "Eight", Value = 8 };

		/// <summary>
		/// Factory to produce a card of rank 9.
		/// </summary>
		public static Rank Nine() => new Rank { Name = "Nine", Value = 9 };

		/// <summary>
		/// Factory to produce a card of rank 10.
		/// </summary>
		public static Rank Ten() => new Rank { Name = "Ten", Value = 10 };

		/// <summary>
		/// Factory to produce a card of rank "Jack".
		/// </summary>
		public static Rank Jack() => new Rank { Name = "Jack", Value = 11 };

		/// <summary>
		/// Factory to produce a card of rank "Queen".
		/// </summary>
		public static Rank Queen() => new Rank { Name = "Queen", Value = 12 };

		/// <summary>
		/// Factory to produce a card of rank "King".
		/// </summary>
		public static Rank King() => new Rank { Name = "King", Value = 13 };

		/// <summary>
		/// Factory method to produce a Rank given its integer value.
		/// </summary>
		/// <param name="value">The value to be converted to Rank</param>
		/// <param name="acesHigh">A bool indicating whether Aces are high or low; default is low</param>
		public static Rank FromValue(int value, bool acesHigh = false)
		{
			switch (value)
			{
				case 1:
					if (!acesHigh)
						return Ace(acesHigh);
					throw new ArgumentException("Rank value of 1 is invalid when aces are high.");
				case 2: return Two();
				case 3: return Three();
				case 4: return Four();
				case 5: return Five();
				case 6: return Six();
				case 7: return Seven();
				case 8: return Eight();
				case 9: return Nine();
				case 10: return Ten();
				case 11: return Jack();
				case 12: return Queen();
				case 13: return King();
				case 14:
					if (acesHigh)
						return Ace(acesHigh);
					throw new ArgumentException("Rank value of 14 is invalid when aces are low");
				default:
					throw new ArgumentException("Invalid rank value; value must be between 1 and 14.");
			}
		}

		#region Operators

		public static bool operator ==(Rank left, Rank right) => left.Equals(right);
		public static bool operator !=(Rank left, Rank right) => !left.Equals(right);

		public static bool operator ==(int left, Rank right) => left == right.Value;
		public static bool operator ==(Rank left, int right) => right == left;
		public static bool operator !=(int left, Rank right) => left != right.Value;
		public static bool operator !=(Rank left, int right) => right != left;

		#endregion Operators

		#region Object overloads

		public override bool Equals(object obj)
		{
			if (obj is Rank other)
				return Value == other.Value;

			if (obj is int val)
				return Value == val;

			return false;
		}

		public override int GetHashCode() => Value.GetHashCode();

		#endregion Object overloads
	}
}
