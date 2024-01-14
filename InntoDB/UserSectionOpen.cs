using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoDB
{
    public class UserSectionOpen
    {
        [Key]
        public int UserSectionID { get; set; }
        public int UserID { get; set; }
        public int SectionID { get; set; }
        public int ViewerID { get; set; }
    }
}
