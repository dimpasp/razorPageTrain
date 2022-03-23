using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext context;
        public ProjectRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Project> AddAsync(Project newProject)
        {
            try
            {
                var employeeName = context
                                .Set<Employee>()
                                .Where(p => p.Id == Convert.ToInt32(newProject.EmployeeName))
                                .Select(p => p.Name)
                                .FirstOrDefault();

                newProject.EmployeeName = employeeName;
            }
            catch (Exception)
            {


            }
            context.Projects.Add(newProject);
            await context.SaveChangesAsync();
            return newProject;
        }
        public async Task<Project> DeleteAsync(int id)
        {
            Project project = context.Projects.Find(id);
            if (project != null)
            {
                context.Projects.Remove(project);
                await context.SaveChangesAsync();
            }
            return project;
        }

        public async Task<Project> getProjectByIdAsync(int projectId)
        {
            var project = context
               .Set<Project>()
               .Where(p => p.id == projectId)
               .AsQueryable();

            return await project.SingleOrDefaultAsync();
        }

        public IEnumerable<Project> GetProjects()
        {
            return context.Projects;
        }

        public IEnumerable<Project> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Projects;
            }
            return context.Projects.Where(e => e.Tittle.Contains(searchTerm));
        }

        public async Task<Project> UpdateAsync(Project updatedProject)
        {
            try
            {
                var employeeName = context
                                .Set<Employee>()
                                .Where(p => p.Id == Convert.ToInt32(updatedProject.EmployeeName))
                                .Select(p => p.Name)
                                .FirstOrDefault();

                updatedProject.EmployeeName = employeeName;
            }
            catch (Exception)
            {
            }
            var project = context.Projects.Attach(updatedProject);
            project.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return updatedProject;
        }
    }
}
