using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer
{
    public class DataManager
    {
        private IProjectsRepository _projectsRepository;
        private IWorkersRepository _workersRepository;

        public DataManager(IProjectsRepository projectsRepository, IWorkersRepository workersRepository)
        {
            _projectsRepository = projectsRepository;
            _workersRepository = workersRepository;
        }

        public IProjectsRepository Projects { get { return _projectsRepository; } }
        public IWorkersRepository Workers { get { return _workersRepository; } }

    }
}
