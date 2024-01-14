using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoDBIntermediate
{
    public static class EncryptedDB
    {
        private static readonly Destructor Finalise = new Destructor();
        static EncryptedDB()
        {
            // One time only constructor.
        }

        private sealed class Destructor
        {
            ~Destructor()
            {
                // One time only destructor.
            }
        }
    }
}
