# tigerpistol-assignment

An implementation of a deck of cards, with functions for shuffling and dealing.

## Usage

```cs
// create a new (unshuffled) deck of 52 cards
var deck = new Deck();

// deal the top card from the deck
Card card = deck.DealTopCard();

// create a deck, shuffle it and deal all cards across a given number of players
Card[][] cards = new Deck()
    .Shuffle()
    .Deal(numberOfPlayers: 4);
```
