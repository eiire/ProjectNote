using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class WorkerService
    {
        private DataManager dataManager;
        public WorkerService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public WorkerViewModel WorkerDBModelToView(int materialId)
        {
            var _model = new WorkerViewModel()
            {
                Worker = dataManager.Workers.GetWorkerById(materialId),
            };
            var _dir = dataManager.Projects.GetProjectById(_model.Worker.ProjectId, true);

            if(_dir.Workers.IndexOf(_dir.Workers.FirstOrDefault(x=>x.Id== _model.Worker.Id)) != _dir.Workers.Count() - 1)
            {
                _model.NextWorker = _dir.Workers.ElementAt(_dir.Workers.IndexOf(_dir.Workers.FirstOrDefault(x => x.Id == _model.Worker.Id)) + 1);
            }
            return _model;
        }

        public WorkerEditModel GetWorkerEdetModel(int workerId)
        {
            var _dbModel = dataManager.Workers.GetWorkerById(workerId);
            var _editModel = new WorkerEditModel() {
                Id = _dbModel.Id = _dbModel.Id,
                Projectid = _dbModel.ProjectId,
                Name=_dbModel.Name,
                SurName = _dbModel.SurName,
                Patronymic = _dbModel.Patronymic,
                Mail = _dbModel.Mail,
            };
            return _editModel;
        }

        public WorkerViewModel SaveWorkerEditModelToDb(WorkerEditModel editModel)
        {
            Worker material;
            if(editModel.Id!=0)
            {
                material = dataManager.Workers.GetWorkerById(editModel.Id);
            }
            else
            {
                material = new Worker();
            }
            material.Name = editModel.Name;
            material.ProjectId = editModel.Projectid;
            material.SurName = editModel.SurName;
            material.Patronymic = editModel.Patronymic;
            material.Mail = editModel.Mail;
            dataManager.Workers.SaveWorker(material);
            return WorkerDBModelToView(material.Id);
        }
        public WorkerEditModel CreateNewWorkerEditModel(int projectId)
        {
            return new WorkerEditModel() { Projectid = projectId };
        }

    }
}
