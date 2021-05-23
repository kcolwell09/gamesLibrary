using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamesLibrary.Models
{
    public class Games
    {
        [Key]
        public int gameID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }

        //set range for review to
        [Range(1, 5)]
        public int Review { get; set; }
        
        public string TextReview { get; set; }
        

    }
}
