using Microsoft.EntityFrameworkCore;
using OnlineEducation.DataAccess.Abstract;
using OnlineEducation.DataAccess.Context;
using OnlineEducation.DataAccess.Repositories;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Concrate
{
    public class CourseRegisterRepository : GenericRepository<CourseRegister>, ICourseRegisterRepository
    {
        public CourseRegisterRepository(OnlineEducationContext context) : base(context)
        {
        }

        public List<CourseRegister> GetAllWithCourse(Expression<Func<CourseRegister, bool>> filter)
        {
             return _context.CourseRegisters.Where(filter).Include(x => x.Course).ToList();
        }
    }
}
