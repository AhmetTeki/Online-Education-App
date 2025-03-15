using OnlineEducation.DataAccess.Abstract;
using OnlineEducation.DataAccess.Context;
using OnlineEducation.DataAccess.Repositories;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Concrate
{
    public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(OnlineEducationContext context) : base(context)
        {
        }

       public void  DontShowOnHome(int id)
        {
            var value = _context.CourseCategories.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

       public void ShowOnHome(int id)
        {
            var value = _context.CourseCategories.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}
