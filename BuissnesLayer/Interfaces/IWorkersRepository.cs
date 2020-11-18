using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IWorkersRepository
    {
        IEnumerable<Worker> GetAllWorkers(bool includeDirectory = false);
        Worker GetWorkerById(int materialId, bool includeDirectory = false);
        void SaveWorker(Worker material);
        void DeleteWorker(Worker material);
    }
}
