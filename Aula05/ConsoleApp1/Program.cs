using System.Text.Json;

namespace ConsoleApp1;
public class Program
{
    static void Main(string[] args)
    {
        // Criando algumas instâncias de músicas
        Music song1 = new Music("Bohemian Rhapsody", "Queen", "A Night at the Opera", "Rock", 1975);
        Music song2 = new Music("Hotel California", "Eagles", "Hotel California", "Rock", 1976);
        Music song3 = new Music("Imagine", "John Lennon", "Imagine", "Rock", 1971);

        // Criando a biblioteca de músicas
        MusicLibrary library = new MusicLibrary();

        // Adicionando as músicas à biblioteca
        library.AddSong(song1);
        library.AddSong(song2);
        library.AddSong(song3);

        // Serializando a biblioteca para JSON e salvando no arquivo
        library.SerializeAndSaveToJson(library.GetMusicList());

        Console.WriteLine("Biblioteca de músicas serializada e salva no arquivo 'musicLibrary.json'.");

        library.ClearLibrary();
       
        List<Music> deserializedSongs = library.DeserializeFromJson("musicLibrary.json");

        if (deserializedSongs.Count > 0)
        {
            // Adicionando músicas desserializadas à biblioteca
            foreach (var song in deserializedSongs)
            {
                library.AddSong(song);
            }

            // Listando as músicas para verificar a desserialização
            library.ListSongs();
        }
        else
        {
            Console.WriteLine("Nenhuma música foi desserializada.");
        }
    }
}







