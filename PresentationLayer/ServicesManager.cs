using BuissnesLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private ProjectService _projectService;
        private WorkerService _workerService;

        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
            _projectService = new ProjectService(_dataManager);
            _workerService = new WorkerService(_dataManager);
        }
        public ProjectService Projects { get { return _projectService; } }
        public WorkerService Workers { get { return _workerService; } }

    }
}
