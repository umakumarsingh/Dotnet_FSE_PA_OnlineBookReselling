using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookReselling.Entities
{
    public class Publisher
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "Publisher Id")]
        public string PublisherId { get; set; }
        [Required]
        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
