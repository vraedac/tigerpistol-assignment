using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerLib
{
	/// <summary>
	/// Represents a deck of cards, with functions for shuffling and dealing.
	/// </summary>
	public class Deck
	{
		private List<Card> _cards;
		private Random _rng;

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

			List<Card> generateFullDeck()
			{
				var result = new List<Card>();

				for (var val = 1; val < 14; val++)
				{
					result.Add(new Card { Suit = Suit.Clubs, Value = val });
					result.Add(new Card { Suit = Suit.Diamonds, Value = val });
					result.Add(new Card { Suit = Suit.Hearts, Value = val });
					result.Add(new Card { Suit = Suit.Spades, Value = val });
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
