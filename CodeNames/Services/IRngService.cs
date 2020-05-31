using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNamesProject.Services
{
    public interface IRngService
    {
        public IEnumerable<string> GetRandomElementsInRange(int numberCount, IEnumerable<string> wordList);

        public IEnumerable<int> CreateAgents(int range);
    }
}
