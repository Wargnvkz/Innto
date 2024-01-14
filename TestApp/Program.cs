using System.Data.Common;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        /*int N = 10000;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            var t = new test();
            t.Text = "test";
            t.Text1 = "test1";
            t.Text2 = "test2";
            t.Text3 = "test3";
            t.Text4 = "".PadLeft(i,'t');
            t.Text5 = "".PadLeft(i, 'w');
            t.Text6 = "".PadLeft(i, 's');
            t.Text7 = "".PadLeft(i, 't');
            InntoDBIntermediate.Encryption.Encrypt(t);
            //Console.WriteLine(t.Text);
            //Console.WriteLine(t.Text1);
            InntoDBIntermediate.Encryption.Decrypt(t);
            //Console.WriteLine(t.Text);
            //Console.WriteLine(t.Text1);
        }
        sw.Stop();
        Console.WriteLine($"{sw.ElapsedTicks/10d/N} мкс");*/
        using (var db = new InntoDB.InntoDB("Server=DESKTOP-25LGUNP\\SQLEXPRESS;Initial Catalog=EFTest;Trusted_Connection=True;TrustServerCertificate=true"))
        {
            db.Users.Add(new InntoDB.User() { Name = "User", Email = "user@server.com" });
            db.SaveChanges();
        }

    }
}

public class test
{
    public string Text;
    public string? Text1;
    public string Text2;
    public string Text3;
    public string Text4;
    public string Text5;
    public string Text6;
    public string Text7;
}