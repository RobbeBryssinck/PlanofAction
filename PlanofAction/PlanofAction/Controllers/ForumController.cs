using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.ViewModels;
using LogicInterfaces;
using LogicFactory;

namespace PlanofAction.Controllers
{
    public class ForumController : Controller
    {
        private IActionPlan actionPlan;
        private IActionPlanCollection actionPlanCollection;

        public ForumController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ForumCategory> forumCategories = db.GetForumCategories();
            return View(forumCategories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(ForumCategory forumCategory)
        {
            int rowsAffected = db.CreateForumCategory(forumCategory);

            if (rowsAffected == 1)
                return RedirectToAction("CategoryCreationSuccessful");
            else
                return RedirectToAction("CategoryCreationFailed");
        }

        [HttpGet]
        public IActionResult CategoryCreationSuccessful()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CategoryCreationFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteCategory(int forumCategoryID)
        {

            return View(db.GetForumCategory(forumCategoryID));
        }

        [HttpPost]
        public IActionResult DeleteCategoryPost(int forumCategoryID)
        {
            ForumCategory forumCategory = db.GetForumCategory(forumCategoryID);
            db.DeleteForumCategory(forumCategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int forumCategoryID)
        {
            return View(db.GetForumCategory(forumCategoryID));
        }

        [HttpPost]
        public IActionResult EditCategoryPost(ForumCategory forumCategory)
        {
            db.EditForumCategory(forumCategory);

            return RedirectToAction("Index");
        }

        public IActionResult ForumThreads(int forumCategoryID)
        {
            List<ForumThread> forumThreads = db.GetForumThreadsByID(forumCategoryID);
            if (forumThreads[0].ThreadID == -1)
                return RedirectToAction("NoForumThreads");
            else
                return View(forumThreads);
        }

        public IActionResult NoForumThreads()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ThreadPage(int threadID)
        {
            return View(db.GetForumThreadViewModel(threadID));
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateForumThreadViewModel createForumThreadViewModel = new CreateForumThreadViewModel()
            {
                AvailableCategories = db.GetForumCategories()
            };

            return View(createForumThreadViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateForumThreadViewModel thread)
        {
            int rowsAffected = db.CreateThread(thread);

            if (rowsAffected == 1)
                return RedirectToAction("CreationSuccessful");
            else
                return RedirectToAction("CreationFailed");
        }

        [HttpGet]
        public IActionResult CreationSuccessful()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreationFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int threadID)
        {
            return View(db.GetForumThread(threadID));
        }

        [HttpPost]
        public IActionResult DeletePost(int threadID)
        {
            ForumThread thread = db.GetForumThread(threadID);
            db.DeleteThread(thread);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int threadID)
        {
            return View(db.GetForumThread(threadID));
        }

        [HttpPost]
        public IActionResult Edit(ForumThread thread)
        {
            db.EditThread(thread);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreatePost(ForumThreadViewModel forumThreadViewModel)
        {
            db.CreatePost(forumThreadViewModel);
            // return to thread with clean input properties 
            return RedirectToAction("ThreadPage", "Forum", new { forumThreadViewModel.ThreadID });
        }

        [HttpGet]
        public IActionResult PostEdit(int postID)
        {
            return View(db.GetPostEditViewModel(postID));
        }

        [HttpPost]
        public IActionResult PostEdit(PostEditViewModel model)
        {
            db.EditPost(model);
            return RedirectToAction("Threadpage", "Forum", new { model.ThreadID });
        }
    }
}