using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerLib
{
	/// <summary>
	/// Represents a deck of cards, with functions for shuffling and dealing.
	/// </summary>
	/// <remarks>
	/// A deck contains 52 cards total, 13 of each suit, and does not include Jokers.  The set of cards in a deck can be manipulated only indirectly via the functions exposed by this class.
	/// </remarks>
	public class Deck
	{
		private List<Card> _cards;
		private readonly Random _rng;

		/// <summary>
		/// Gets the cards in the deck.
		/// </summary>
		public Card[] Cards
		{
			get => _cards.ToArray();
		}

		public Deck()
		{
			_cards = generateFullDeck();
			_rng = new Random();

			static List<Card> generateFullDeck()
			{
				var result = new List<Card>();

				for (var val = 1; val < 14; val++)
				{
					result.Add(new Card { Suit = Suit.Clubs, Rank = Rank.FromValue(val) });
					result.Add(new Card { Suit = Suit.Diamonds, Rank = Rank.FromValue(val) });
					result.Add(new Card { Suit = Suit.Hearts, Rank = Rank.FromValue(val) });
					result.Add(new Card { Suit = Suit.Spades, Rank = Rank.FromValue(val) });
				}

				return result;
			}
		}

		/// <summary>
		/// Shuffles the deck in place, reordering the cards randomly each time.  Returns this instance.
		/// </summary>
		/// <returns>This instance</returns>
		public Deck Shuffle()
		{
			_cards = _cards.OrderBy(x => _rng.Next()).ToList();
			return this;
		}

		/// <summary>
		/// Deals the first card off of the top of the deck.
		/// </summary>
		public Card DealTopCard()
		{
			if (_cards.Count == 0)
				throw new InvalidOperationException("Cannot deal any more cards because the deck is empty.");

			var result = _cards.First();
			_cards.RemoveAt(0);
			return result;
		}

		/// <summary>
		/// Deals the deck across a specified number of players until no cards remain in the deck.
		/// </summary>
		/// <param name="numberOfPlayers"></param>
		/// <returns>A two dimensional array representing the hands of each player</returns>
		public Card[][] Deal(int numberOfPlayers)
		{
			if (numberOfPlayers < 0 || numberOfPlayers > 52)
				throw new ArgumentException("The number of players must be between 0 and 52");

			Card? dealtCard = null;
			var result = new List<List<Card>>();

			do
			{
				dealtCard = null;
				for (int i = 0; i < numberOfPlayers; i++)
				{
					if (_cards.Count == 0)
						break;

					if (result.Count < (i + 1))
						result.Add(new List<Card>());

					dealtCard = DealTopCard();
					result.ElementAt(i).Add(dealtCard.Value);
				}

			} while (dealtCard != null);

			return result.Select(x => x.ToArray()).ToArray();
		}
	}
}
