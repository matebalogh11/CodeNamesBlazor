using System.Collections.Generic;

namespace CodeNamesProject.Services
{
    public interface IWordProvider
    {
        public IEnumerable<string> GetAllWords();

        public void AddWord(string word);

        public IEnumerable<string> GetWordListForGame( int tableSize = 25 );
    }
}
