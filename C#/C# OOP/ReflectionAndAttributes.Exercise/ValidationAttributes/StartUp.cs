namespace ValidationAttributes
{
    using ValidationAttributes.IO;
    using ValidationAttributes.IO.Writers;
    using ValidationAttributes.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Hristo",
                 1
             );

            bool isValidEntity = Validator.IsValid(person);

            IWriter writer = new ConsoleWriter();
            writer.Write(isValidEntity);
            // Console.WriteLine(isValidEntity);
        }
    }
}
