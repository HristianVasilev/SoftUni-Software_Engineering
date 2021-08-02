namespace _01._BrowserHistory
{
    using _01._BrowserHistory.Interfaces;
    using System;

    public class Link : ILink , IComparable<ILink>
    {
        public Link(string url, int loadingTime)
        {
            this.Url = url;
            this.LoadingTime = loadingTime;
        }

        public string Url { get; set; }
        public int LoadingTime { get; set; }

        public int CompareTo(ILink other)
        {
            if (this.Url.CompareTo(other.Url) == 0)
            {
                return this.LoadingTime.CompareTo(other.LoadingTime);
            }
            return this.Url.CompareTo(other.Url);
        }

        public override string ToString()
        {
            return $"-- {this.Url} {this.LoadingTime}s";
        }
    }
}
