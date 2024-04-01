using LessonsManagement.Business.Models;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Conciliation
{
    public class ConciliationList
    {
        public IEnumerable<Match> Match;
        public IEnumerable<Divergency> Divergencies;
    }
}
