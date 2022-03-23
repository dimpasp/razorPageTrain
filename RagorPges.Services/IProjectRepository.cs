using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Services
{
    public interface IProjectRepository
    {
        Task<Project> getProjectByIdAsync(int projectId);
        IEnumerable<Project> Search(string searchTerm);
        Task<Project> UpdateAsync(Project updatedProject);
        Task<Project> AddAsync(Project newProject);
        IEnumerable<Project> GetProjects();
        Task<Project> DeleteAsync(int id);
    }
}
