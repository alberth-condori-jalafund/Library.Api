using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
