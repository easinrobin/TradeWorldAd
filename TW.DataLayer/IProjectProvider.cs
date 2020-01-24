using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.Models;

namespace TW.DataLayer
{
    public interface IProjectProvider
    {
        List<Project> GetAllProject();
        Project GetProjectById(long Id);
        long InsertProject(Project project);
        bool UpdateProject(Project projects);
        bool DeleteProject(long Id);
    }
}
