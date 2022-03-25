using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please add title")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
