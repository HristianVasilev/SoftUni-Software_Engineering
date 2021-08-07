using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            // spy.RevealPrivateMethods("Stealer.Hacker");
            //spy.AnalyzeAccessModifiers("Stealer.Hacker");
            //spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            Console.WriteLine(result);
        }
    }
}
