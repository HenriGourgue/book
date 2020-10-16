using System.Collections.Generic;

namespace book.Domain
{
    public class Root    {
        public string kind { get; set; } 
        public int totalItems { get; set; } 
        public List<Item> items { get; set; } 
    }
}