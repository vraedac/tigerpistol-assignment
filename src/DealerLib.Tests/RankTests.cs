using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerLib;
using NUnit.Framework;
using FluentAssertions;

namespace DealerLib.Tests
{
	[TestFixture]
	public class RankTests
	{
		#region Factories

		[Test]
		public void RankFactory_Ace()
		{
			Rank.Ace().Value.Should().Be(1);
			Rank.Ace().Name.Should().Be("Ace");
			Rank.Ace(high: false).Value.Should().Be(1);
			Rank.Ace(high: false).Name.Should().Be("Ace");
			Rank.Ace(high: true).Value.Should().Be(14);
			Rank.Ace(high: true).Name.Should().Be("Ace");
		}

		[Test]
		public void RankFactory_Two()
		{
			Rank.Two().Value.Should().Be(2);
			Rank.Two().Name.Should().Be("Two");
		}

		[Test]
		public void RankFactory_Three()
		{
			Rank.Three().Value.Should().Be(3);
			Rank.Three().Name.Should().Be("Three");
		}

		[Test]
		public void RankFactory_Four()
		{

			Rank.Four().Value.Should().Be(4);
			Rank.Four().Name.Should().Be("Four");
		}

		[Test]
		public void RankFactory_Five()
		{

			Rank.Five().Value.Should().Be(5);
			Rank.Five().Name.Should().Be("Five");
		}

		[Test]
		public void RankFactory_Six()
		{

			Rank.Six().Value.Should().Be(6);
			Rank.Six().Name.Should().Be("Six");
		}

		[Test]
		public void RankFactory_Seven()
		{

			Rank.Seven().Value.Should().Be(7);
			Rank.Seven().Name.Should().Be("Seven");
		}

		[Test]
		public void RankFactory_Eight()
		{

			Rank.Eight().Value.Should().Be(8);
			Rank.Eight().Name.Should().Be("Eight");
		}

		[Test]
		public void RankFactory_Nine()
		{

			Rank.Nine().Value.Should().Be(9);
			Rank.Nine().Name.Should().Be("Nine");
		}

		[Test]
		public void RankFactory_Ten()
		{
			Rank.Ten().Value.Should().Be(10);
			Rank.Ten().Name.Should().Be("Ten");

		}

		[Test]
		public void RankFactory_Jack()
		{
			Rank.Jack().Value.Should().Be(11);
			Rank.Jack().Name.Should().Be("Jack");

		}

		[Test]
		public void RankFactory_Queen()
		{
			Rank.Queen().Value.Should().Be(12);
			Rank.Queen().Name.Should().Be("Queen");

		}

		[Test]
		public void RankFactory_King()
		{
			Rank.King().Value.Should().Be(13);
			Rank.King().Name.Should().Be("King");

		}

		[Test]
		public void ValueFactory_Ace()
		{
			Rank.FromValue(1).Value.Should().Be(1);
			Rank.FromValue(1).Name.Should().Be("Ace");
			Rank.FromValue(1, acesHigh: false).Value.Should().Be(1);
			Rank.FromValue(1, acesHigh: false).Name.Should().Be("Ace");
			Rank.FromValue(14, acesHigh: true).Value.Should().Be(14);
			Rank.FromValue(14, acesHigh: true).Name.Should().Be("Ace");
		}

		[Test]
		public void ValueFactory_Two()
		{
			Rank.FromValue(2).Value.Should().Be(2);
			Rank.FromValue(2).Name.Should().Be("Two");
		}

		[Test]
		public void ValueFactory_Three()
		{
			Rank.FromValue(3).Value.Should().Be(3);
			Rank.FromValue(3).Name.Should().Be("Three");
		}

		[Test]
		public void ValueFactory_Four()
		{
			Rank.FromValue(4).Value.Should().Be(4);
			Rank.FromValue(4).Name.Should().Be("Four");
		}

		[Test]
		public void ValueFactory_Five()
		{
			Rank.FromValue(5).Value.Should().Be(5);
			Rank.FromValue(5).Name.Should().Be("Five");
		}

		[Test]
		public void ValueFactory_Six()
		{
			Rank.FromValue(6).Value.Should().Be(6);
			Rank.FromValue(6).Name.Should().Be("Six");
		}

		[Test]
		public void ValueFactory_Seven()
		{
			Rank.FromValue(7).Value.Should().Be(7);
			Rank.FromValue(7).Name.Should().Be("Seven");
		}

		[Test]
		public void ValueFactory_Eight()
		{
			Rank.FromValue(8).Value.Should().Be(8);
			Rank.FromValue(8).Name.Should().Be("Eight");
		}

		[Test]
		public void ValueFactory_Nine()
		{
			Rank.FromValue(9).Value.Should().Be(9);
			Rank.FromValue(9).Name.Should().Be("Nine");
		}

		[Test]
		public void ValueFactory_Ten()
		{
			Rank.FromValue(10).Value.Should().Be(10);
			Rank.FromValue(10).Name.Should().Be("Ten");
		}

		[Test]
		public void ValueFactory_Jack()
		{
			Rank.FromValue(11).Value.Should().Be(11);
			Rank.FromValue(11).Name.Should().Be("Jack");
		}

		[Test]
		public void ValueFactory_Queen()
		{
			Rank.FromValue(12).Value.Should().Be(12);
			Rank.FromValue(12).Name.Should().Be("Queen");
		}

		[Test]
		public void ValueFactory_King()
		{
			Rank.FromValue(13).Value.Should().Be(13);
			Rank.FromValue(13).Name.Should().Be("King");
		}

		[Test]
		public void ValueFactory_InvalidValue_Throws([Range(-10, 20)] int value)
		{
			if (value < 1 || value > 14)
				this.Invoking(x => Rank.FromValue(value)).Should().Throw<ArgumentException>();
		}

		[Test]
		public void ValueFactory_OneWhenAcesHigh_Throws() => this.Invoking(x => Rank.FromValue(1, acesHigh: true)).Should().Throw<ArgumentException>();

		[Test]
		public void ValueFactory_FourteenWhenAcesLow_Throws() => this.Invoking(x => Rank.FromValue(14, acesHigh: false)).Should().Throw<ArgumentException>();

		#endregion Factories

		#region Operators

		[Test]
		public void Operator_Equal_BetweenRanks()
		{
			Rank.Five().Equals(Rank.Five()).Should().BeTrue();
			(Rank.Five() == Rank.Five()).Should().BeTrue();
			Rank.Five().Equals(Rank.Four()).Should().BeFalse();
			(Rank.Five() == Rank.Four()).Should().BeFalse();
		}

		[Test]
		public void Operator_Equal_BetweenRankAndInteger()
		{
			Rank.Five().Equals(5).Should().BeTrue();
			(Rank.Five() == 5).Should().BeTrue();
			(5 == Rank.Five()).Should().BeTrue();
			Rank.Five().Equals(4).Should().BeFalse();
			(Rank.Five() == 4).Should().BeFalse();
			(4 == Rank.Five()).Should().BeFalse();
		}

		[Test]
		public void Operator_NotEqual_BetweenRanks()
		{
			(Rank.Five() != Rank.Five()).Should().BeFalse();
			(Rank.Five() != Rank.Four()).Should().BeTrue();
		}

		[Test]
		public void Operator_NotEqual_BetweenRankAndInteger()
		{
			(Rank.Five() != 5).Should().BeFalse();
			(5 != Rank.Five()).Should().BeFalse();
			(Rank.Five() != 4).Should().BeTrue();
			(4 != Rank.Five()).Should().BeTrue();
		}

		#endregion Operators
	}
}
