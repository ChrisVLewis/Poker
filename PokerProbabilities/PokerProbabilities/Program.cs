using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace PokerProbabilities
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PokerProbabilities");
            var MongoDB_url = new MongoUrl("mongodb://localhost:27017");
            var client = new MongoClient(MongoDB_url);
            var Poker_Database = client.GetDatabase("Poker");
            var Deck_Collection = Poker_Database.GetCollection<BsonDocument>("Deck");
            var Hands_Collection = Poker_Database.GetCollection<BsonDocument>("Hands");

            SetUpInitialPokerCollections();



            Console.ReadLine();
        }

        public static void SetUpInitialPokerCollections()
        {
            var MongoDB_url = new MongoUrl("mongodb://localhost:27017");
            var client = new MongoClient(MongoDB_url);
            var Poker_Database = client.GetDatabase("Poker");
            var Deck_Collection = Poker_Database.GetCollection<BsonDocument>("Deck");
            var Hands_Collection = Poker_Database.GetCollection<BsonDocument>("Hands");
            var Deck_List = new List<Card>();
            var Deck_Bson = new List<BsonDocument>();
            var Hands_List = new List<Hand>();
            var Hands_Bson = new List<BsonDocument>();
            var deleteFilter = Builders<BsonDocument>.Filter.Empty;



            Deck_Collection.DeleteMany(deleteFilter);
            Hands_Collection.DeleteMany(deleteFilter);

            foreach(var card_name in Enum.GetValues(typeof(PokerConstants.CardNames)))
            {
                foreach(var card_suit in Enum.GetValues(typeof(PokerConstants.CardSuit)))
                {
                    var deck_card = new Card((PokerConstants.CardNames)card_name, (PokerConstants.CardSuit)card_suit);
                    Deck_List.Add(deck_card);
                }
            }

            foreach(var card1 in Deck_List)
            {
                foreach(var card2 in Deck_List)
                {
                    if(card1 != card2)
                    {
                        bool addhand = true;
                        var temp_hand = new Hand(card1, card2);
                        foreach(var vhand in Hands_List)
                        {
                            if(temp_hand == vhand)
                            {
                                addhand = false;
                            }
                        }
                        if(addhand)
                        {
                            Hands_List.Add(temp_hand);
                        }
                    }
                }
            }

            foreach(var hand in Hands_List)
            {
                Console.WriteLine(hand);
            }

            //Deck_Collection.InsertOne(deck_card.ToBson());
            //Deck_Collection.InsertMany()
        }


    }
}
