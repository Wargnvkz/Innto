using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoClasses
{
    public class Section
    {
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
