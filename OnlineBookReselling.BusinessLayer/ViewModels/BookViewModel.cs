using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookReselling.BusinessLayer.ViewModels
{
    public class BookViewModel
    {
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
