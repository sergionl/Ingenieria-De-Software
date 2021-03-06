using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetSkole.Entities
{
    public class Game:EntityBase
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        [Required]
        [StringLength(256)]
        public string Link { get; set; }
    }
}
