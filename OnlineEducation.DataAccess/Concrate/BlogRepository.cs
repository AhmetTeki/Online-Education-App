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
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    { 
        private readonly OnlineEducationContext _educontext;
        public BlogRepository(OnlineEducationContext _context) : base(_context)
        {
            _educontext = _context;
        }

        List<Blog> IBlogRepository.GetBlogWithCategories()
        {
            return _educontext.Blogs.Include(x => x.BlogCategory).ToList();
        }
    }
}
