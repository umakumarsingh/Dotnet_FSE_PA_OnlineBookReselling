using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookReselling.Entities
{
    public class Order
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "Order Id")]
        public string OrderId { get; set; }
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }
        [Display(Name = "Book Id")]
        public string BookId { get; set; }
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public Double Amount { get; set; }
    }
}
