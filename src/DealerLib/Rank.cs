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

		public static Rank Ace(bool high = false)
		{
			return new Rank { Name = "Ace", Value = high ? 14 : 1 };
		}

		public static Rank Two() => new Rank { Name = "Two", Value = 2 };
		public static Rank Three() => new Rank { Name = "Three", Value = 3 };
		public static Rank Four() => new Rank { Name = "Four", Value = 4 };
		public static Rank Five() => new Rank { Name = "Five", Value = 5 };
		public static Rank Six() => new Rank { Name = "Six", Value = 6 };
		public static Rank Seven() => new Rank { Name = "Seven", Value = 7 };
		public static Rank Eight() => new Rank { Name = "Eight", Value = 8 };
		public static Rank Nine() => new Rank { Name = "Nine", Value = 9 };
		public static Rank Ten() => new Rank { Name = "Ten", Value = 10 };
		public static Rank Jack() => new Rank { Name = "Jack", Value = 11 };
		public static Rank Queen() => new Rank { Name = "Queen", Value = 12 };
		public static Rank King() => new Rank { Name = "King", Value = 13 };

		/// <summary>
		/// Factory method to produce a Rank given its integer value.
		/// </summary>
		public static Rank FromValue(int value)
		{
			switch (value)
			{
				case 1:
					// TODO check if aces are high
					return Ace();
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
				default:
					throw new ArgumentException("Invalid rank value; value must be between 1 and 14.");
			}
		}

		public static bool operator ==(Rank left, Rank right) => left.Equals(right);
		public static bool operator !=(Rank left, Rank right) => !left.Equals(right);

		public static bool operator ==(int left, Rank right) => left == right.Value;
		public static bool operator ==(Rank left, int right) => right == left;
		public static bool operator !=(int left, Rank right) => left != right.Value;
		public static bool operator !=(Rank left, int right) => right != left;

		public override bool Equals(object obj)
		{
			if (obj is Rank other)
				return this.Value == other.Value;

			return false;
		}

		public override int GetHashCode() => Value.GetHashCode();
	}
}
