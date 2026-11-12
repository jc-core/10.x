using System.Text.Json;
using System.Xml.Serialization;
namespace Assignment10_1 {
    internal class SaveFuncs {

        public static void SaveXml(List<Book> books, string path) {

            using FileStream stream = new(path, FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new(typeof(List<Book>));
            serializer.Serialize(stream, books);

        }

        public static List<Book> LoadXml(string path) {

            using FileStream stream = new(path, FileMode.Open, FileAccess.Read);
            XmlSerializer serializer = new(typeof(List<Book>));

            return serializer.Deserialize(stream) as List<Book> ?? new List<Book>();

        }

        public static void SaveJson(List<Book> books, string path) {

            using FileStream stream = new(path, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(stream, books, new JsonSerializerOptions { WriteIndented = true });

        }

        public static List<Book> LoadJson(string path) {

            using FileStream stream = new(path, FileMode.Open, FileAccess.Read);

            return JsonSerializer.Deserialize<List<Book>>(stream) ?? new List<Book>();

        }
    }
}
