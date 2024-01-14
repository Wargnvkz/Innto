using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoDB
{
    //To Encrypt
    public class UserSectionValue
    {
        [Key]
        public int UserSectionID {  get; set; }
        public int UserID { get; set; }
        public int SectionID { get; set; }
        public int SectionFieldNumber {  get; set; }
        [EncryptColumn]
        public string? Text { get; set; }
        public int? SelectectValue { get; set; }
        public int? Number { get; set; }
        [EncryptColumn]
        public byte[]? Image{ get; set; }
    }
}
