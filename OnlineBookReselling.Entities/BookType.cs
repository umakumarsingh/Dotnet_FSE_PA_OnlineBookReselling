using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookReselling.Entities
{
    public class BookType
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "Book Type Id")]
        public string BookTypeId { get; set; }
        [Required]
        [Display(Name = "Type Of Book")]
        public string TypeofBook { get; set; }
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
