using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.ViewModels;
using LogicInterfaces;
using LogicFactory;
using System.Configuration;

namespace PlanofAction.Controllers
{
    public class ForumController : Controller
    {
        private IForumCategory forumCategory;
        private IForumCategoryCollection forumCategoryCollection;
        private IForumThread forumThread;
        private IForumThreadCollection forumThreadCollection;
        private IForumPost forumPost;
        private IForumPostCollection forumPostCollection;
        private IAccount account;
        private IAccountCollection accountCollection;

        public ForumController()
        {
            forumCategory = LogicFactory.LogicFactory.GetForumCategory();
            forumCategoryCollection = LogicFactory.LogicFactory.GetForumCategoryCollection();
            forumThread = LogicFactory.LogicFactory.GetForumThread();
            forumThreadCollection = LogicFactory.LogicFactory.GetForumThreadCollection();
            forumPost = LogicFactory.LogicFactory.GetForumPost();
            forumPostCollection = LogicFactory.LogicFactory.GetForumPostCollection();
            account = LogicFactory.LogicFactory.GetAccount();
            accountCollection = LogicFactory.LogicFactory.GetAccountCollection();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ForumIndexViewModel model = new ForumIndexViewModel();
            model.ForumCategories = forumCategoryCollection.GetForumCategories();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel model)
        {
            forumCategory.ForumCategoryString = model.ForumCategoryString;

            int rowsAffected = forumCategoryCollection.CreateForumCategory(forumCategory);

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
            forumCategory = forumCategoryCollection.GetForumCategory(forumCategoryID);

            DeleteCategoryViewModel model = new DeleteCategoryViewModel
            {
                ForumCategoryID = forumCategory.ForumCategoryID,
                ForumCategoryString = forumCategory.ForumCategoryString
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteCategoryPost(int forumCategoryID)
        {
            forumCategory.ForumCategoryID = forumCategoryID;
            forumCategory.DeleteForumCategory();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int forumCategoryID)
        {
            forumCategory = forumCategoryCollection.GetForumCategory(forumCategoryID);

            EditCategoryViewModel model = new EditCategoryViewModel
            {
                ForumCategoryID = forumCategory.ForumCategoryID,
                ForumCategoryString = forumCategory.ForumCategoryString
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategoryPost(EditCategoryViewModel model)
        {
            forumCategory.ForumCategoryID = model.ForumCategoryID;
            forumCategory.ForumCategoryString = model.ForumCategoryString;

            forumCategory.EditForumCategory();

            return RedirectToAction("Index");
        }

        public IActionResult ForumThreads(int forumCategoryID)
        {
            ForumThreadsViewModel model = new ForumThreadsViewModel();

            model.ForumThreads = forumThreadCollection.GetForumThreads(forumCategoryID);
            model.ForumCategory = forumCategoryCollection.GetForumCategory(forumCategoryID);

            if (model.ForumThreads[0].ThreadID == -1)
            {
                NoForumThreadsViewModel noForumModel = new NoForumThreadsViewModel()
                {
                    ForumCategoryID = model.ForumCategory.ForumCategoryID,
                    ForumCategoryString = model.ForumCategory.ForumCategoryString
                };
                return View("NoForumThreads", noForumModel);
            }
            else
                return View(model);
        }

        [HttpGet]
        public IActionResult ThreadPage(int threadID)
        {
            forumThread = forumThreadCollection.GetForumThread(threadID);
            account = accountCollection.GetAccount(forumThread.AccountID);
            List<IForumPost> forumPosts = forumPostCollection.GetForumPosts(threadID);

            ForumThreadViewModel model = new ForumThreadViewModel()
            {
                ThreadID = forumThread.ThreadID,
                ThreadCreator = account,
                ThreadTitle = forumThread.ThreadTitle,
                ThreadMessage = forumThread.ThreadMessage,
                ThreadDateCreated = forumThread.ThreadDateCreated,
                Posts = forumPosts
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateForumThreadViewModel model = new CreateForumThreadViewModel()
            {
                AvailableCategories = forumCategoryCollection.GetForumCategories()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateForumThreadViewModel model)
        {
            forumThread.AccountID = model.AccountID;
            forumThread.ThreadTitle = model.ThreadTitle;
            forumThread.ThreadMessage = model.ThreadMessage;
            forumThread.ThreadDateCreated = model.ThreadDateCreated;
            forumThread.ForumCategoryID = model.ForumCategoryID;

            int rowcount = forumThreadCollection.CreateForumThread(forumThread);

            if (rowcount == 1)
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
            forumThread = forumThreadCollection.GetForumThread(threadID);

            DeleteThreadViewModel model = new DeleteThreadViewModel()
            {
                ForumThread = forumThread,
                ForumCategory = forumCategoryCollection.GetForumCategory(forumThread.ForumCategoryID)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeletePost(int threadID)
        {
            forumThread = forumThreadCollection.GetForumThread(threadID);
            forumThread.DeleteForumThread();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int threadID)
        {
            forumThread = forumThreadCollection.GetForumThread(threadID);
            EditThreadViewModel model = new EditThreadViewModel()
            {
                ThreadID = forumThread.ThreadID,
                ThreadMessage = forumThread.ThreadMessage
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditThreadViewModel model)
        {
            forumThread.ThreadID = model.ThreadID;
            forumThread.ThreadMessage = model.ThreadMessage;

            forumThread.EditForumThread();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreatePost(ForumThreadViewModel forumThreadViewModel)
        {
            forumPost.ThreadID = forumThreadViewModel.ThreadID;
            forumPost.AccountID = forumThreadViewModel.PosterAccountID;
            forumPost.PostMessage = forumThreadViewModel.PosterMessage;

            forumPostCollection.CreatePost(forumPost);

            return RedirectToAction("ThreadPage", "Forum", new { forumThreadViewModel.ThreadID });
        }

        [HttpGet]
        public IActionResult PostEdit(int postID)
        {
            forumPost = forumPostCollection.GetForumPost(postID);

            PostEditViewModel model = new PostEditViewModel()
            {
                PostID = forumPost.PostID,
                ThreadID = forumPost.ThreadID,
                PostMessage = forumPost.PostMessage
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PostEdit(PostEditViewModel model)
        {
            forumPost.PostID = model.PostID;
            forumPost.PostMessage = model.PostMessage;

            forumPost.EditPost();

            return RedirectToAction("Threadpage", "Forum", new { model.ThreadID });
        }
    }
}