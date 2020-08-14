using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerLib
{
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

				for (var val = 0; val < 13; val++)
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
		/// Shuffles the deck, reordering the cards randomly each time.
		/// </summary>
		public Deck Shuffle()
		{
			_cards = _cards.OrderBy(x => _rng.Next()).ToList();
			return this;
		}

		/// <summary>
		/// Deals the first card off of the top of the deck.
		/// </summary>
		public Card Pop()
		{
			var result = _cards.First();
			_cards.RemoveAt(0);
			return result;
		}

		public Card[] Deal()
		{
			var result = _cards.ToArray();
			_cards.Clear();
			return result;
		}

		/// <summary>
		/// Deals the deck across a specified number of players until no cards remain in the deck.
		/// </summary>
		/// <param name="numberOfPlayers"></param>
		/// <returns>A two dimensional array representing the hands of each player</returns>
		public Card[][] Deal(int numberOfPlayers)
		{
			Card dealtCard = null;
			var result = new List<List<Card>>();

			do
			{
				for (int i = 0; i < numberOfPlayers; i++)
				{
					if (result.Count < (i + 1))
						result.Add(new List<Card>());

					dealtCard = Pop();
					result.ElementAt(i).Add(dealtCard);
				}

			} while (dealtCard != null);

			return result.Select(x => x.ToArray()).ToArray();
		}
	}
}
