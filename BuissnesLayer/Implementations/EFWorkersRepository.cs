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
    public class EFWorkersRepository : IWorkersRepository
    {
        private EFDBContext context;
        public EFWorkersRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Worker> GetAllWorkers(bool includeProject = false)
        {
            if (includeProject)
                return context.Set<Worker>().Include(x => x.Project).AsNoTracking().ToList();
            else
                return context.Worker.ToList();
        }

        public Worker GetWorkerById(int workerId, bool includeProject = false)
        {
            if (includeProject)
                return context.Set<Worker>().Include(x => x.Project).AsNoTracking().FirstOrDefault(x => x.Id == workerId);
            else
                return context.Worker.FirstOrDefault(x => x.Id == workerId);
        }

        public void SaveWorker(Worker worker)
        {
            if (worker.Id == 0)
                context.Worker.Add(worker);
            else
                context.Entry(worker).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteWorker(Worker material)
        {
            context.Worker.Remove(material);
            context.SaveChanges();
        }
    }
}
