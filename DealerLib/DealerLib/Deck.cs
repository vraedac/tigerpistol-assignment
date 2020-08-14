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

		public Deck Shuffle()
		{
			_cards = _cards.OrderBy(x => _rng.Next()).ToList();
			return this;
		}

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
	}
}
