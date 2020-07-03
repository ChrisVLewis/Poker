using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerProbabilities
{
    public class Hand : IEquatable<Hand>
    {
        public Card Card1;
        public Card Card2;

        public Hand(Card card1, Card card2)
        {
            Card1 = card1;
            Card2 = card2;          
        }

        public BsonDocument ToBson()
        {
            var document = new BsonDocument
            {
                { "Hand Name", Card1.ToString() + "/" + Card2.ToString() },
                { "Card One", Card1.ToString() },
                { "Card Two", Card2.ToString() }
            };

            return document;
        }

        public static bool operator ==(Hand obj1, Hand obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(Hand obj1, Hand obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(Hand other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Hand);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Card1.GetHashCode() ^ Card2.GetHashCode();
            }
        }
    }
}
