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
    public class PresenceSituationService
    {
        private readonly ApplicationDbContext.ApplicationDbContext context;
        private readonly OptionPresence.OptionPresenceService optionPresenceService;

        public PresenceSituationService(ApplicationDbContext.ApplicationDbContext context, OptionPresence.OptionPresenceService optionPresenceFunctions)
        {
            this.context = context;
            this.optionPresenceService = optionPresenceFunctions;
        }

        public async Task<int> AddOrUpdate(ClassStudentPresentialSituationViewModel model)
        {
            var studentPresentialSituation = model.CopyToEntity<ApplicationDbContext.StudentPresenceSituation>();

            if (!model.StudentPresenceId.HasValue)
            {
                await this.context.StudentPresenceSituation.AddAsync(studentPresentialSituation);
            }
            else
            {
                studentPresentialSituation = this.context.StudentPresenceSituation.Single(x => x.StudentPresenceId == model.StudentPresenceId);

                model.CopyToEntity<ApplicationDbContext.StudentPresenceSituation>(ref studentPresentialSituation);
                this.context.StudentPresenceSituation.Update(studentPresentialSituation);
            }

            await this.context.SaveChangesAsync();
            return await Task.Run(() => studentPresentialSituation.StudentPresenceId);
        }
        public async Task<List<ClassStudentPresentialSituationViewModel>> List()
        {
            return await (from x in this.context.StudentPresenceSituation
                          join cs in this.context.ClassStudent on x.ClassStudentId equals cs.ClassStudentId
                          join s in this.context.Student on cs.StudentId equals s.StudentId
                          join opSaturday in context.OptionPresence on x.Saturday equals opSaturday.OptionPresenceId
                          join opSunday in context.OptionPresence on x.Sunday equals opSunday.OptionPresenceId
                          select new ClassStudentPresentialSituationViewModel
                          {
                              ClassStudentId = x.ClassStudentId,
                              Module = x.Module,
                              Sunday = x.Sunday,
                              SundayDate = x.SundayDate,
                              Saturday = x.Saturday,
                              SaturdayDate = x.SaturdayDate,
                              Comments = x.Comments,
                              SaturdayComments = x.SaturdayComments,
                              StudentPresenceId = x.StudentPresenceId,
                              SundayComments = x.SundayComments,
                              SaturdayOptionPresence = opSaturday.Description,
                              SundayOptionPresence = opSunday.Description,
                              StudentName = s.Name
                          }).ToListAsync();
        }
        public async Task<List<ClassStudentPresentialSituationViewModel>> List(int classStudentId)
        {
            return await (from x in this.context.StudentPresenceSituation
                          join cs in this.context.ClassStudent on x.ClassStudentId equals cs.ClassStudentId
                          join s in this.context.Student on cs.StudentId equals s.StudentId
                          join opSaturday in context.OptionPresence on x.Saturday equals opSaturday.OptionPresenceId
                          join __opSunday in context.OptionPresence on x.Sunday equals __opSunday.OptionPresenceId into _opSunday
                          from opSunday in _opSunday.DefaultIfEmpty()
                          where x.ClassStudentId == classStudentId
                          select new ClassStudentPresentialSituationViewModel
                          {
                              ClassStudentId = x.ClassStudentId,
                              Module = x.Module,
                              Sunday = x.Sunday,
                              SundayDate = x.SundayDate,
                              Saturday = x.Saturday,
                              SaturdayDate = x.SaturdayDate,
                              Comments = x.Comments,
                              SaturdayComments = x.SaturdayComments,
                              StudentPresenceId = x.StudentPresenceId,
                              SundayComments = x.SundayComments,
                              SaturdayOptionPresence = opSaturday.Description,
                              SundayOptionPresence = opSunday == null ? "-" : opSunday.Description,
                              ActivityGrade = x.ActivityGrade,
                              CompletionPercent = x.CompletionPercent,
                              TestGrade = x.TestGrade,
                              StudentName = s.Name
                          }).ToListAsync();
        }
        public bool UsingModule(int? studentPresenceId, int classStudentId, int module)
        {
            if (studentPresenceId.HasValue)
                return this.context.StudentPresenceSituation.Any(x => x.StudentPresenceId != studentPresenceId.Value && x.ClassStudentId == classStudentId && x.Module == module);
            else
                return this.context.StudentPresenceSituation.Any(x => x.ClassStudentId == classStudentId && x.Module == module);
        }
        public async Task Remove(int studentPresenceId)
        {
            this.context.StudentPresenceSituation.Remove(this.context.StudentPresenceSituation.Single(x => x.StudentPresenceId == studentPresenceId));
            await this.context.SaveChangesAsync();
        }
    }
}
