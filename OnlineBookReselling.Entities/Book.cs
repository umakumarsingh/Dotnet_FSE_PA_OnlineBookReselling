using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookReselling.Entities
{
    public class Book
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "Book Id")]
        public string BookId { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string BookTypeId { get; set; }
        public string PublisherId { get; set; }
        public DateTime PublishedOn { get; set; }
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }
        public string Remark { get; set; }
        public virtual Publisher Publishers { get; set; }
    }
}
