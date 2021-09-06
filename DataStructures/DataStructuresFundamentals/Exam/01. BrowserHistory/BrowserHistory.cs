namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        //private Dictionary<string, LinkedList<ILink>> linksDict;
        //private SortedSet<string> urls;

        private LinkedList<ILink> linkedList;


        public BrowserHistory()
        {
            //    this.linksDict = new Dictionary<string, LinkedList<ILink>>();
            //    this.urls = new SortedSet<string>();
            this.linkedList = new LinkedList<ILink>();
        }

        // public IEnumerable<ILink> Links => this.linksDict.SelectMany(v => v.Value);

        public int Size => this.linkedList.Count; // this.Links.Count();

        public void Open(ILink link)
        {
            this.linkedList.AddLast(link);

            //if (!this.linksDict.ContainsKey(link.Url))
            //{
            //    this.linksDict.Add(link.Url, new LinkedList<ILink>());
            //}

            //this.linksDict[link.Url].AddLast(link);
        }

        public ILink GetByUrl(string url)
        {
            return this.linkedList.FirstOrDefault(x => x.Url == url);

            //if (!this.linksDict.ContainsKey(url))
            //{
            //    return null;
            //}

            //return this.linksDict[url].First.Value;
        }

        public bool Contains(ILink link)
        {
            return this.linkedList.Contains(link);

            //if (this.linksDict.ContainsKey(link.Url))
            //{
            //    var links = this.linksDict[link.Url];

            //    return links.Contains(link);
            //}

            //return false;
        }

        public ILink LastVisited()
        {
            EnsureNotEmpty();

            return this.linkedList.Last.Value;
            //return this.linksDict.Last().Value.Last.Value;
        }



        public ILink DeleteLast()
        {
            ILink lastLink = this.LastVisited();

            //this.linksDict[lastLink.Url].RemoveLast();
            this.linkedList.RemoveLast();

            return lastLink;
        }

        public ILink DeleteFirst()
        {
            EnsureNotEmpty();

            ILink firstLink = this.linkedList.First.Value; // this.linksDict.First().Value.First();

            //  this.linksDict[firstLink.Url].RemoveFirst();
            this.linkedList.RemoveFirst();

            return firstLink;
        }

        public int RemoveLinks(string url)
        {
            //IEnumerable<string> urls = this.linksDict.Select(k => k.Key);

            //IEnumerable<string> urlsToRemove = urls.Where(x => x.ToLower().Contains(url.ToLower()));

            // int count = 0;

            //foreach (var urlPath in urlsToRemove)
            //{
            //    count += this.linksDict[urlPath].Count;
            //    this.linksDict.Remove(urlPath);
            //}

            LinkedList<ILink> newLinkedList = new LinkedList<ILink>();

            foreach (var link in this.linkedList)
            {
                if (!link.Url.ToLower().Contains(url.ToLower()))
                {
                    newLinkedList.AddLast(link);
                }
            }

            int count = this.linkedList.Count - newLinkedList.Count;
            this.linkedList = newLinkedList;

            return count;
        }

        public void Clear()
        {
            this.linkedList.Clear();
            // this.linksDict.Clear();
        }

        public ILink[] ToArray()
        {
            return this.linkedList.Reverse().ToArray();

            //  return this.linksDict.SelectMany(v => v.Value).Reverse().ToArray();
        }

        public List<ILink> ToList()
        {
            return this.ToArray().ToList();
        }

        public string ViewHistory()
        {
            if (this.Size == 0)
            {
                return "Browser history is empty!";
            }

            ILink[] links = this.ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var link in links)
            {
                sb.AppendLine(link.ToString());
            }

            return sb.ToString();
        }



        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
