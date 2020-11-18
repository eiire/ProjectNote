using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implementations
{
    public class EFProjectsRepository : IProjectsRepository
    {
        private EFDBContext context;
        public EFProjectsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAllProjects(bool includeWorkers = false)
        {
            if (includeWorkers)
                return context.Set<Project>().Include(x => x.Workers).AsNoTracking().ToList();
            else
                return context.Project.ToList();
        }

        public Project GetProjectById(int projectId, bool includeWorkers = false)
        {
            if (includeWorkers)
                return context.Set<Project>().Include(x => x.Workers).AsNoTracking().FirstOrDefault(x => x.Id == projectId);
            else
                return context.Project.FirstOrDefault(x => x.Id == projectId);
        }

        public void SaveProject(Project project)
        {
            if (project.Id == 0)
                context.Project.Add(project);
            else
                context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            context.Project.Remove(project);
            context.SaveChanges();
        }
    }
}
