using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer
    {
        private IDictionary<string, Track> tracksCollection;
        private IDictionary<string, string> tracksByTitles;
        private IDictionary<string, ISet<string>> albums;
        private Queue<string> listeningQueue;


        public RePlayer()
        {
            this.tracksCollection = new Dictionary<string, Track>();
            this.tracksByTitles = new Dictionary<string, string>();
            this.albums = new Dictionary<string, ISet<string>>();
            this.listeningQueue = new Queue<string>();
        }


        public int Count => this.tracksCollection.Count;

        public void AddTrack(Track track, string album)
        {
            if (this.tracksCollection.ContainsKey(track.Id))
                throw new ArgumentException();

            this.tracksCollection.Add(track.Id, track);
            this.tracksByTitles.Add(track.Title, track.Id);

            if (!this.albums.ContainsKey(album))
            {
                this.albums.Add(album, new SortedSet<string>());
            }

            this.albums[album].Add(track.Id);
        }

        public bool Contains(Track track)
        {
            return this.tracksCollection.ContainsKey(track.Id);
        }

        public Track GetTrack(string title, string albumName)
        {
            if (!this.ContainsAlbum(albumName))
                throw new ArgumentException();

            Track track = this.GetTrack(title);
            if (track == null)
                throw new ArgumentException();

            return track;
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!this.ContainsAlbum(albumName))
                throw new ArgumentException();

            IEnumerable<Track> tracks = this.albums[albumName]
                .Select(tId => this.tracksCollection[tId]);

            return tracks.OrderByDescending(t => t.Plays);
        }

        public void AddToQueue(string trackName, string albumName)
        {
            if (!this.ContainsAlbum(albumName))
                throw new ArgumentException();

            Track track = this.GetTrack(trackName);
            if (track == null)
                throw new ArgumentException();

            this.listeningQueue.Enqueue(track.Id);
        }

        public Track Play()
        {
            if (this.listeningQueue.Count == 0)
                throw new ArgumentException();

            string trackId = this.listeningQueue.Dequeue();
            Track track = this.tracksCollection[trackId];
            track.Plays++;

            return track;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            if (!this.ContainsAlbum(albumName))
                throw new ArgumentException();

            Track track = this.GetTrack(trackTitle);
            if (track == null)
                throw new ArgumentException();

            this.tracksCollection.Remove(track.Id);
            this.tracksByTitles.Remove(trackTitle);
            this.albums[albumName].Remove(track.Id);
            this.listeningQueue = this.RemoveFromQueue(track.Id);
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            IEnumerable<Track> tracks = this.tracksCollection.Values
                .Where(t => t.DurationInSeconds >= lowerBound && t.DurationInSeconds <= upperBound);

            if (tracks.Count() == 0)
                return Enumerable.Empty<Track>();

            return tracks.OrderBy(t => t.DurationInSeconds).ThenByDescending(t => t.Plays);
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            //List<Track> tracks = new List<Track>();
            //var keys = this.albums.Keys.OrderBy(k => k);

            //foreach (var key in keys)
            //{
            //    var currentTracks = this.GetTracks(this.albums[key])
            //        .OrderByDescending(t => t.Plays)
            //        .ThenByDescending(t => t.DurationInSeconds);
            //    tracks.AddRange(currentTracks);
            //}

            //if (tracks.Count == 0)
            //    return Enumerable.Empty<Track>();

            //return tracks;

            var keys = this.albums.Keys.OrderBy(k => k);

            if (keys.Count() == 0)
                return Enumerable.Empty<Track>();

            IEnumerable<Track> tracks = keys
                .SelectMany(
                    k => this.albums[k]
                    .Select(trackId => this.tracksCollection[trackId])
                    .OrderByDescending(t => t.Plays)
                    .ThenByDescending(t => t.DurationInSeconds));


            return tracks;
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            Dictionary<string, List<Track>> tracks = new Dictionary<string, List<Track>>();

            foreach (var key in this.albums.Keys)
            {
                var currentTracks = this.GetTracks(this.albums[key])
                    .Where(t => t.Artist == artistName);

                if (!tracks.ContainsKey(key))
                    tracks.Add(key, new List<Track>());

                tracks[key] = currentTracks.ToList();
            }

            if (tracks.Count == 0)
                throw new ArgumentException();

            return tracks;
        }




        private IEnumerable<Track> GetTracks(IEnumerable<string> keys)
        {
            ICollection<Track> tracks = new List<Track>();

            foreach (var key in keys)
            {
                tracks.Add(this.tracksCollection[key]);
            }

            return tracks;
        }

        private bool ContainsTrackTitle(string title)
        {
            Track track = this.GetTrack(title);

            return track != null ? true : false;
        }

        private bool ContainsAlbum(string albumName)
        {
            return this.albums.ContainsKey(albumName);
        }

        private Queue<string> RemoveFromQueue(string id)
        {
            Queue<string> queue = new Queue<string>();

            while (this.listeningQueue.Count != 0)
            {
                string trackId = this.listeningQueue.Dequeue();
                if (trackId == id) continue;
                queue.Enqueue(trackId);
            }

            return queue;
        }

        private Track GetTrack(string title)
        {
            if (!this.tracksByTitles.ContainsKey(title))
                return null;

            string trackId = this.tracksByTitles[title];

            return this.tracksCollection[trackId];
        }
    }
}
