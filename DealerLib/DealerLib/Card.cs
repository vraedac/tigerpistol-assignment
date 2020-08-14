using System;
using System.Collections.Generic;
using System.Text;

namespace DealerLib
{
	public class Card
	{
		public Suit Suit { get; set; }
		public int Value; // 1(A), 2, 3, 4, 5, 6, 7, 8, 9, 10, 11(J), 12(Q), 13(K)
	}
}
