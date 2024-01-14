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

    public class User
    {
        [Key]
        public int UserID { get; set; }
        [EncryptColumn]
        public string? Name { get; set; }
        public string? PasswordHash { get; set; }
        [EncryptColumn]
        public string? Email { get; set; }

    }
}
