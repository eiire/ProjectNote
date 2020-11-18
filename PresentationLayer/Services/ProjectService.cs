using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class ProjectService
    {
        private DataManager _dataManager;
        private WorkerService _materialService;
        public ProjectService(DataManager dataManager)
        {
            this._dataManager = dataManager;
            _materialService = new WorkerService(dataManager);
        }

        public List<ProjectViewModel> GetProjectsList()
        {
            var _dirs = _dataManager.Projects.GetAllProjects();
            List<ProjectViewModel> _modelsList = new List<ProjectViewModel>();
            foreach (var item in _dirs)
            {
                _modelsList.Add(ProjectDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public ProjectViewModel ProjectDBToViewModelById(int directoryId)
        {
            var _project = _dataManager.Projects.GetProjectById(directoryId, true);

            List<WorkerViewModel> _materialsViewModelList = new List<WorkerViewModel>();
            foreach (var item in _project.Workers)
            {
                _materialsViewModelList.Add(_materialService.WorkerDBModelToView(item.Id));
            }
            return new ProjectViewModel() { Project = _project, Workers = _materialsViewModelList };
        }
        public ProjectEditModel GetProjectEditModel(int projectid = 0)
        {
            if (projectid != 0)
            {
                var _dirDB = _dataManager.Projects.GetProjectById(projectid);
                var _dirEditModel = new ProjectEditModel() {
                    Id = _dirDB.Id,
                    Name = _dirDB.Name,
                    NameExeCompany = _dirDB.NameExeCompany,
                    InformationProjectManager = _dirDB.InformationProjectManager,
                    DataExeProject = _dirDB.DataExeProject,
                    DatesProject = _dirDB.DatesProject,
                    ProjectPriority = _dirDB.ProjectPriority
                };
                return _dirEditModel;
            }
            else { return new ProjectEditModel() { }; }
        }
        public ProjectViewModel SaveProjectEditModelToDb(ProjectEditModel directoryEditModel)
        {
            Project _directoryDbModel;
            if(directoryEditModel.Id!=0)
            {
                _directoryDbModel = _dataManager.Projects.GetProjectById(directoryEditModel.Id);
            }
            else
            {
                _directoryDbModel = new Project();
            }
            _directoryDbModel.Name = directoryEditModel.Name;
            _directoryDbModel.NameExeCompany = directoryEditModel.NameExeCompany;
            _directoryDbModel.InformationProjectManager = directoryEditModel.InformationProjectManager;
            _directoryDbModel.DataExeProject = directoryEditModel.DataExeProject;
            _directoryDbModel.DatesProject = directoryEditModel.DatesProject;
            _directoryDbModel.ProjectPriority = directoryEditModel.ProjectPriority;

            _dataManager.Projects.SaveProject(_directoryDbModel);

            return ProjectDBToViewModelById(_directoryDbModel.Id);
        }

        public ProjectEditModel CreateNewProjectEditModel()
        {
            return new ProjectEditModel() { };
        }
    }
}
