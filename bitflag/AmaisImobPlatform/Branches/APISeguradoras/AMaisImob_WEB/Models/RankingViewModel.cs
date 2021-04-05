using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class RankingViewModel
    {

        public RankingViewModel()
        {
            Top2Index = new CompanyRankData();
            Top1Index = new CompanyRankData();
            MidIndex = new CompanyRankData();
            Bottom1Index = new CompanyRankData();
            Bottom2Index = new CompanyRankData();
        }
        public int LastPosition { get; set; }
        public int Top2Position { get { return MidPosition - 2; } }
        public int Top1Position { get { return MidPosition - 1; } }
        public int MidPosition { get; set; }
        public int Bottom1Position { get { return MidPosition + 1; } }
        public int Bottom2Position { get { return MidPosition + 2; } }

        public CompanyRankData Top2Index { get; set; }
        public CompanyRankData Top1Index { get; set; }
        public CompanyRankData MidIndex { get; set; }
        public CompanyRankData Bottom1Index { get; set; }
        public CompanyRankData Bottom2Index { get; set; }

    }
}
