using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoClasses
{
    //To Encrypt
    public class UserSectionValue
    {
        public int UserSectionID {  get; set; }
        public int UserID { get; set; }
        public int SectionID { get; set; }
        public int SectionFieldNumber {  get; set; }
        public string? Text { get; set; }
        public int? SelectectValue { get; set; }
        public int? Number { get; set; }
        public byte[]? Image{ get; set; }
    }
}
