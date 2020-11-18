using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IProjectsRepository
    {
        IEnumerable<Project> GetAllProjects(bool includeMaterials = false);
        Project GetProjectById(int directoryId, bool includeMaterials = false);
        void SaveProject(Project achieve);
        void DeleteProject(Project achieve);
    }
}
