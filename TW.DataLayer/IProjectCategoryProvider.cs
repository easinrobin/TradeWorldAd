using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.Models;

namespace TW.DataLayer
{
    public interface IProjectCategoryProvider
    {
        List<ProjectCategory> GetAllProjectCategory();
        ProjectCategory GetProjectCategoryById(long Id);
        long InsertProjectCategory(ProjectCategory category);
        bool UpdateProjectCategory(ProjectCategory category);
        bool DeleteProjectCategory(long Id);
    }
}
