using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoClasses
{
    //To Encrypt
    public class UsersPersonalMessage
    {
        public int UsersPersonalMessageID {  get; set; }
        public int SenderID {  get; set; }
        public int Receiver { get; set; }
        public string? Text {  get; set; }

    }
}
