using DTO.ClassStudent;
using DTO.Student;
using DTO.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClassStudent
{
    public class FinanceService
    {
        private readonly ApplicationDbContext.ApplicationDbContext context;

        public FinanceService(ApplicationDbContext.ApplicationDbContext context, OptionPresence.OptionPresenceService optionPresenceFunctions)
        {
            this.context = context;
        }
        public async Task<List<ApplicationDbContext.Finance>> List(int classStudentId)
        {
            return await context.Finance.Where(x => x.ClassStudentId == classStudentId).OrderBy(x => x.Installment).ToListAsync();
        }
    }
}
