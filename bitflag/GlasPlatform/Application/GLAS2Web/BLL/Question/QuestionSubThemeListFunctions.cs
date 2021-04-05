using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Question
{
    public class QuestionSubThemeListFunctions : BLLBasicListFunctions<QuestionSubThemeList>
    {
        public QuestionSubThemeListFunctions(GLAS2Context context) : base(context, "QuestionSubThemeId")
        {
        }

        protected override void SetDbSet() => this.dbSet = context.QuestionSubThemeList;
    }
}
