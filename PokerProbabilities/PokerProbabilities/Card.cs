using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace PokerProbabilities
{
    public class Card
    {
        public PokerConstants.CardNames Name;
        public PokerConstants.CardSuit Suit;
        public int NameValue;
        public int SuitValue;

        public Card(PokerConstants.CardNames card_name, PokerConstants.CardSuit card_suit)
        {
            Name = card_name;
            Suit = card_suit;
            NameValue = (int)card_name;
            SuitValue = (int)card_suit;
        }

        public BsonDocument ToBson()
        {
            string temp_name = Enum.GetName(typeof(PokerConstants.CardNames), Name);
            string temp_suit = Enum.GetName(typeof(PokerConstants.CardSuit), Suit);

            var document = new BsonDocument
            {
                { "Name", temp_name },
                { "Suit", temp_suit },
                { "NameValue", NameValue },
                { "SuitValue", SuitValue }
            };

            return document;
        }

        public override string ToString()
        {
            var stringName = Enum.GetName(typeof(PokerConstants.CardNames), Name);
            var stringSuit = (PokerConstants.CardSuit)SuitValue;
            return stringName + " of " + stringSuit;
        }
    }
}
