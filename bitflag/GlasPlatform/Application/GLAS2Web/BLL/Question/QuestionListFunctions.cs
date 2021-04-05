using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Question
{
    public class QuestionListFunctions : BLLBasicListFunctions<QuestionList>
    {
        public QuestionListFunctions(GLAS2Context context) : base(context, "QuestionId")
        {
        }

        protected override void SetDbSet() => this.dbSet = context.QuestionList;
    }
}
