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
			// Arrange/Act
			var sut = new Deck();

			// Assert
			sut.Cards.Should().HaveCount(52);
		}

		[Test]
		public void Ctor_GeneratesCorrectSuits()
		{
			// Arrange/Act
			var sut = new Deck();

			// Assert
			sut.Cards.Should().HaveCount(52);
			sut.Cards.Where(x => x.Suit == Suit.Clubs).Should().HaveCount(13);
			sut.Cards.Where(x => x.Suit == Suit.Diamonds).Should().HaveCount(13);
			sut.Cards.Where(x => x.Suit == Suit.Hearts).Should().HaveCount(13);
			sut.Cards.Where(x => x.Suit == Suit.Spades).Should().HaveCount(13);
		}

		[Test]
		public void Ctor_GeneratesCorrectCardValues()
		{
			// Arrange/Act
			var sut = new Deck();

			// Assert
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

		[Test]
		public void DeckCards_SetIsImmutable()
		{
			// Arrange
			var sut = new Deck();
			var cards = sut.Cards;

			// Act
			cards[0].Value = 999;

			// Assert
			sut.Cards[0].Value.Should().NotBe(999);
		}

		[Test]
		public void DealTopCard_DealsCorrectCard()
		{
			// Arrange
			var sut = new Deck();
			Card expected = sut.Cards[0];

			// Act
			Card result = sut.DealTopCard();

			// Assert
			result.Should().Be(expected);
		}

		[Test]
		public void DealTopCard_RemovesCardFromDeck()
		{
			// Arrange
			var sut = new Deck();
			Card expected = sut.Cards[0];

			// Act
			sut.DealTopCard();

			// Assert
			sut.Cards.Should().HaveCount(51);
			sut.Cards[0].Should().NotBe(expected);
		}

		[Test]
		public void DealTopCard_DealsAllCardsWithoutErrors()
		{
			// Arrange
			var sut = new Deck();

			// Act/Assert
			for (int i = 0; i < 52; i++)
				sut.Invoking(x => x.DealTopCard()).Should().NotThrow();
		}

		[Test]
		public void DealTopCard_ThrowsAfterLastCardDealt()
		{
			// Arrange
			var sut = new Deck();

			for (int i = 0; i < 52; i++)
				sut.DealTopCard();

			// Act/Assert
			sut.Invoking(x => x.DealTopCard()).Should().Throw<InvalidOperationException>();
		}

		[Test]
		public void DealAll_ArbitraryValidPlayerCount([Range(1, 52)] int playerCount)
		{
			// Arrange
			var sut = new Deck();

			// Act
			Card[][] playerHands = sut.Deal(playerCount);

			// Assert
			playerHands.Should().HaveCount(playerCount);

			var remainder = 52 % playerCount;
			for (int i = 0; i < playerCount; i++)
			{
				if (remainder-- <= 0)
					playerHands[i].Should().HaveCount(52 / playerCount);
				else
					playerHands[i].Should().HaveCount(52 / playerCount + 1);
			}
		}

		[Test]
		public void DealAll_ZeroPlayers_DealsNoCards()
		{
			// Arrange
			var sut = new Deck();

			// Act
			Card[][] playerHands = sut.Deal(0);

			// Assert
			playerHands.Should().BeEmpty();
		}

		[Test]
		public void DealAll_NegativePlayerCount_Throws()
		{
			// Arrange
			var sut = new Deck();

			// Act/Assert
			sut.Invoking(x => x.Deal(-1)).Should().Throw<ArgumentException>();
		}

		[Test]
		public void DealAll_TooManyPlayers_Throws()
		{
			// Arrange
			var sut = new Deck();

			// Act/Assert
			sut.Invoking(x => x.Deal(53)).Should().Throw<ArgumentException>();
		}
	}
}
