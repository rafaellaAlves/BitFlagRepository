using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Question
{
    public class QuestionAnswerListFunctions : BLLBasicListFunctions<QuestionAnswerList>
    {
        public QuestionAnswerListFunctions(DAL.GLAS2Context context) : base(context, "QuestionAnswerId")
        {
        }

        protected override void SetDbSet() => this.dbSet = context.QuestionAnswerList;
    }
}
