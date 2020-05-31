using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNamesProject.Services
{
    public class DotNetRngService : IRngService
    {
        private static Random RandomField;

        public DotNetRngService()
        {
            RandomField = new Random();
        }

        public IEnumerable<int> CreateAgents(int range)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetRandomElementsInRange( int numberCount, IEnumerable<string> wordList )
        {
            if (numberCount > wordList.Count())
                return null;

            return wordList.OrderBy(w => RandomField.Next()).Take(numberCount);
        }
    }
}
