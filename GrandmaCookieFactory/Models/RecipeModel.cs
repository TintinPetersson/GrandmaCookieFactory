using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrandmaCookieFactory.Models
{
    public class RecipeModel
    {
        [Required(ErrorMessage ="Fuck you")]
        public string Name { get; set; }
        public Dictionary<string, string> Ingredients { get; set; } = new Dictionary<string, string>();
        [Required]
        public int Popularity { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
