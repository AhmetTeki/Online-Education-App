using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Abstract
{
   public interface ICourseRegisterRepository : IRepository<CourseRegister>
    {
        List<CourseRegister> GetAllWithCourse(Expression<Func<CourseRegister, bool>> filter);
    }
}
