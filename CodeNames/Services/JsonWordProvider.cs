using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeNamesProject.Services
{
    public class JsonWordProvider : IWordProvider
    {
        public JsonWordProvider(IWebHostEnvironment webHostEnvironment,
                                IRngService rngService )
        {
            WebHostEnvironment = webHostEnvironment;
            RandomService = rngService;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
        public IRngService RandomService { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "WordList.json"); }
        }

        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return;

            var words = GetAllWords().ToList();
            if (!words.Select( w => w.ToLower()).Contains(word.ToLower()))
            {
                words.Add(word);
                using var stream = File.OpenWrite(JsonFileName);
                JsonSerializer.Serialize(new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true }), words);
            }
        }

        public IEnumerable<string> GetAllWords()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<IEnumerable<string>>(jsonFileReader.ReadToEnd());
        }

        public IEnumerable<string> GetWordListForGame( int tableSize = 25 )
        {
            return RandomService.GetRandomElementsInRange(tableSize, GetAllWords());
        }
    }
}
