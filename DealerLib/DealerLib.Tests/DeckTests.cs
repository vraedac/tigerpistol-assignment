using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace DealerLib.Tests
{
	[TestFixture]
	public class DeckTests
	{
		[Test]
		public void Ctor_GeneratesCorrectNumberOfCards()
		{
			var sut = new Deck();
			sut.Cards.Should().HaveCount(52);
		}

		[Test]
		public void Ctor_GeneratesCorrectSuits()
		{
			var sut = new Deck();

			sut.Cards.Should().HaveCount(52);
			sut.Cards.Where(x => x.Suit == Suit.Clubs).Should().HaveCount(13);
			sut.Cards.Where(x => x.Suit == Suit.Diamonds).Should().HaveCount(13);
			sut.Cards.Where(x => x.Suit == Suit.Hearts).Should().HaveCount(13);
			sut.Cards.Where(x => x.Suit == Suit.Spades).Should().HaveCount(13);
		}

		[Test]
		public void Ctor_GeneratesCorrectCardValues()
		{
			var sut = new Deck();

			sut.Cards.Where(x => x.Value == 1).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 2).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 3).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 4).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 5).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 6).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 7).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 8).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 9).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 10).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 11).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 12).Should().HaveCount(4);
			sut.Cards.Where(x => x.Value == 13).Should().HaveCount(4);
		}
	}
}
