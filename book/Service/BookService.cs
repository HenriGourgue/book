using book.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using book.Service.dto;

namespace book.Service
{
    public class BookService
    {
        static HttpClient client = new HttpClient();

        public Boolean insertInShelve(BookDto book)
        {
            MongoClient dbClient = new MongoClient ("mongodb://127.0.0.1:27017");

            var database = dbClient.GetDatabase ("tp");
            var collection = database.GetCollection<BsonDocument> ("shelve");
            
            collection.InsertOne(book.ToBsonDocument());

            return true;
        }

        public List<BookResult> getShelves()
        {
            List<BookResult> pto = new List<BookResult>();
            MongoClient dbClient = new MongoClient ("mongodb://127.0.0.1:27017");

            var database = dbClient.GetDatabase ("tp");
            var collection = database.GetCollection<BookResult>("shelve");
            var documents = collection.Find(new BsonDocument()).ToCursor();
            
            foreach (var document in documents.ToEnumerable())
            {
                pto.Add(document);
            }
            
            Console.WriteLine(pto.Count);

            return pto;
        }

        public BookDto getBooksByTitle(string title)
        {
            
            HttpResponseMessage response = client.GetAsync("https://www.googleapis.com/books/v1/volumes?q=intitle+" + title).Result;
            response.EnsureSuccessStatusCode();
            string data = response.Content.ReadAsStringAsync().Result; 

            Root root = JsonConvert.DeserializeObject<Root>(data);
            
            MongoClient dbClient = new MongoClient ("mongodb://127.0.0.1:27017");

            var database = dbClient.GetDatabase ("tp");
            var collection = database.GetCollection<BsonDocument> ("books");
            
            collection.InsertOne(convertToDto(root).ToBsonDocument());

            return convertToDto(root);
        }
        
        private BookDto convertToDto(Root root)
        {
            if (root == null) return null;

            return new BookDto(
                    
            ){title= root.items[0].volumeInfo.title,
                authors= root.items[0].volumeInfo.authors,
                pageCount= root.items[0].volumeInfo.pageCount,
                publisher= root.items[0].volumeInfo.publisher,
                publishedDate= root.items[0].volumeInfo.publishedDate,
                description= root.items[0].volumeInfo.description,
                industryIdentifiers= root.items[0].volumeInfo.industryIdentifiers,
                printType= root.items[0].volumeInfo.printType,
                averageRating= root.items[0].volumeInfo.averageRating,
                ratingsCount= root.items[0].volumeInfo.ratingsCount,
                imageLinks= root.items[0].volumeInfo.imageLinks,
                language= root.items[0].volumeInfo.language,
                previewLink= root.items[0].volumeInfo.previewLink,
                infoLink= root.items[0].volumeInfo.infoLink};
        }
            
    }
}