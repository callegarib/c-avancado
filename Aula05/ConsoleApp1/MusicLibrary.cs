using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1;

public class MusicLibrary
{
    public List<Music> songs;

    public MusicLibrary()
    {
        songs = new List<Music>();
    }

    public void AddSong(Music song)
    {
        songs.Add(song);
    }

    public void ListSongs()
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("A biblioteca de músicas está vazia.");
        }
        else
        {
            Console.WriteLine("Lista de músicas na biblioteca:");
            foreach (var song in songs)
            {
                Console.WriteLine($"Título: {song.Title}, Artista: {song.Artist}, Álbum: {song.Album}, Gênero: {song.Genre}, Ano: {song.Year}");
            }
        }
    }

    public void SerializeAndSaveToJson(List<Music> musicList)
    {
        try
        {
            string json = JsonSerializer.Serialize(musicList);

            // Caminho do arquivo para salvar o JSON
            string filePath = "musicLibrary.json";

            // Escreve o JSON em um arquivo
            File.WriteAllText(filePath, json);

            Console.WriteLine("JSON das músicas serializado e salvo com sucesso no arquivo 'musicLibrary.json'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao serializar e salvar o JSON: {ex.Message}");
        }
    }

    public List<Music> DeserializeFromJson(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                List<Music> deserializedMusicList = JsonSerializer.Deserialize<List<Music>>(jsonData);

                if (deserializedMusicList != null)
                {
                    Console.WriteLine("Músicas desserializadas com sucesso do arquivo JSON.");
                    return deserializedMusicList;
                }
                else
                {
                    Console.WriteLine("Não foi possível desserializar as músicas do arquivo JSON.");
                }
            }
            else
            {
                Console.WriteLine("O arquivo JSON não existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao desserializar do arquivo JSON: {ex.Message}");
        }

        return new List<Music>(); // Retorna uma lista vazia caso ocorra algum erro
    }


    public List<Music> GetMusicList()
    {
        return songs; // Retorna a lista de músicas
    }

    public void ClearLibrary()
    {
        songs.Clear();
    }
}
