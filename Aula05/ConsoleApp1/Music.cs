using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1;

public class Music
{
    public string Title {  get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public Music(string title, string artist, string album, string genre, int year)
    {
        Title = title;
        Artist = artist;
        Album = album;
        Genre = genre;
        Year = year;
    }
    public Music()
    {
    }
}
