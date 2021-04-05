using DTO.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Course
{
    public class CourseService
    {
        private ApplicationDbContext.ApplicationDbContext applicationDbContext;
        public CourseService(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<List<CourseViewModel>> List()
        {
            return await applicationDbContext.Course.Select(x => new CourseViewModel()
            {
                CourseId = x.CourseId,
                Name = x.Name,
                DefaultModuleCount = x.DefaultModuleCount
            }).ToListAsync();
        }
    }
}
