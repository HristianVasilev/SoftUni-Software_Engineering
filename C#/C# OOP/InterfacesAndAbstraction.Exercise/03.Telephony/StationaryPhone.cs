namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
