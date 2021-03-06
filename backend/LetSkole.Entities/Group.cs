using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetSkole.Entities
{
    public class Group:EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        public int MaxGrade { get; set; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                Group g = (Group)obj;
                return Id == g.Id;
            }
        }
    }
}
