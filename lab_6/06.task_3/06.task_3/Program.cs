using System;
using System.Collections.Generic;

namespace OnlineRadio
{
    public class InvalidSongException : Exception
    {
        public InvalidSongException() : base("Invalid song.") { }
    }

    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException() : base() { }
        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }

    public class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException() : base() { }
        public override string Message => "Song name should be between 3 and 30 symbols.";
    }

    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException() : base() { }
        public override string Message => "Invalid song length.";
    }

    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException() : base() { }
        public override string Message => "Song minutes should be between 0 and 14.";
    }

    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException() : base() { }
        public override string Message => "Song seconds should be between 0 and 59.";
    }

    public class Song
    {
        private string artist;
        private string name;
        private int minutes;
        private int seconds;

        public Song(string artist, string name, int minutes, int seconds)
        {
            Artist = artist;
            Name = name;
            Minutes = minutes;
            Seconds = seconds;
        }

        public string Artist
        {
            get => artist;
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                    throw new InvalidArtistNameException();
                artist = value;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                    throw new InvalidSongNameException();
                name = value;
            }
        }

        public int Minutes
        {
            get => minutes;
            private set
            {
                if (value < 0 || value > 14)
                    throw new InvalidSongMinutesException();
                minutes = value;
            }
        }

        public int Seconds
        {
            get => seconds;
            private set
            {
                if (value < 0 || value > 59)
                    throw new InvalidSongSecondsException();
                seconds = value;
            }
        }

        public int TotalSeconds => Minutes * 60 + Seconds;
    }

    class Program
    {
        static void Main()
        {
            List<Song> playlist = new List<Song>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(';');
                string artist = input[0];
                string songName = input[1];
                string[] time = input[2].Split(':');
                int minutes = int.Parse(time[0]);
                int seconds = int.Parse(time[1]);

                try
                {
                    Song song = new Song(artist, songName, minutes, seconds);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Songs added: {playlist.Count}");

            int totalSeconds = 0;
            foreach (var song in playlist)
                totalSeconds += song.TotalSeconds;

            int hours = totalSeconds / 3600;
            int minutesTotal = (totalSeconds % 3600) / 60;
            int secondsTotal = totalSeconds % 60;

            Console.WriteLine($"Playlist length: {hours}h {minutesTotal}m {secondsTotal}s");
        }
    }
}
