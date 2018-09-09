using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PravaStranaUlice.Models
{
    public partial class BlogLanding
    {
        public IEnumerable<BlogDetail> GetPosts(int itemsPerPage, int currentPage = 0)
        {
            return Children.OfType<BlogDetail>().Skip(currentPage*itemsPerPage).Take(itemsPerPage);
        }
    }
}
