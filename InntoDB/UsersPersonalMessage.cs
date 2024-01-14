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
    public class UsersPersonalMessage
    {
        [Key]
        public int UsersPersonalMessageID {  get; set; }
        public int SenderID {  get; set; }
        public int Receiver { get; set; }
        [EncryptColumn]
        public string? Text {  get; set; }

    }
}
