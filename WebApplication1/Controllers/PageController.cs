using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;
using static DataLayer.Enums.PageEnums;

namespace WebApplication1.Controllers
{
    public class PageController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public PageController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }
        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageType.Project: _viewModel = _servicesmanager.Projects.ProjectDBToViewModelById(pageId); break;
                case PageType.Worker: _viewModel = _servicesmanager.Workers.WorkerDBModelToView(pageId); break;
                default: _viewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_viewModel);
        }

        [HttpGet]
        public IActionResult PageEditor(int pageId, PageType pageType, int projectId = 0)
        {
            PageEditModel _editModel;

            switch (pageType)
            {
                case PageType.Project:
                    if (pageId != 0) _editModel = _servicesmanager.Projects.GetProjectEditModel(pageId);
                    else _editModel = _servicesmanager.Projects.CreateNewProjectEditModel();
                    break;
                case PageType.Worker:
                    if (pageId != 0) _editModel = _servicesmanager.Workers.GetWorkerEdetModel(pageId);
                    else _editModel = _servicesmanager.Workers.CreateNewWorkerEditModel(projectId);
                    break;
                default: _editModel = null; break;
            }

            ViewBag.PageType = pageType;
            return View(_editModel);
        }

        [HttpPost]
        public IActionResult SaveProject(ProjectEditModel model)
        {
            _servicesmanager.Projects.SaveProjectEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType=PageType.Project });
        }

        [HttpPost]
        public IActionResult SaveWorker (WorkerEditModel model)
        {
            _servicesmanager.Workers.SaveWorkerEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType=PageType.Worker });
        }
    }
}
