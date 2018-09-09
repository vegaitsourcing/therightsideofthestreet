using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace PravaStranaUlice.Models
{
    public partial class AthleteLandingPage : PublishedContentModel, IPage
    {
        public IEnumerable<Athlete> GetAthletes(int itemsPerPage, int currentPage = 0)
        {
            return Children.OfType<Athlete>().Skip(currentPage * itemsPerPage).Take(itemsPerPage);
        }
    }
}
