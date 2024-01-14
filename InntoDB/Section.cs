using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoDB
{
    public class Section
    {
        [Key]
        public int SectionID { get;set; }
        public string? Name { get;set; }
        public SectionType SectionType { get;set; }

    }
    public enum SectionType
    {
        General,
        Personal,
        Intimate
    }
}
