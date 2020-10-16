using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace book.Domain
{
    public class BookResult
    {
        [BsonId]
        [JsonPropertyName("id")] public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        [JsonPropertyName("title")] public string title { get; set; }
        [JsonPropertyName("authors")] public List<string> authors { get; set; }
        [JsonPropertyName("pageCount")] public int pageCount { get; set; }
        [JsonPropertyName("publisher")] public string publisher { get; set; }
        [JsonPropertyName("publishedDate")] public string publishedDate { get; set; }
        [JsonPropertyName("description")] public string description { get; set; }
        [JsonPropertyName("industryIdentifiers")] public List<IndustryIdentifier> industryIdentifiers { get; set; }
        [JsonPropertyName("printType")] public string printType { get; set; }
        [JsonPropertyName("averageRating")] public double averageRating { get; set; }
        [JsonPropertyName("ratingsCount")] public int ratingsCount { get; set; }
        [JsonPropertyName("imageLinks")] public ImageLinks imageLinks { get; set; }
        [JsonPropertyName("language")] public string language { get; set; }
        [JsonPropertyName("previewLink")] public string previewLink { get; set; }
        [JsonPropertyName("infoLink")] public string infoLink { get; set; }
    }
}