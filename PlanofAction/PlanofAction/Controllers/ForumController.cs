﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.Models;

namespace PlanofAction.Controllers
{
    public class ForumController : Controller
    {
        private PoAContext db;
        public ForumController(PoAContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.GetForumThreads());
        }

        [HttpGet]
        public IActionResult ThreadPage(int threadID)
        {
            return View(db.GetForumThread(threadID));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Thread thread)
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

        //TODO: simplify method (GetForumThread unnecessary)
        [HttpPost]
        public IActionResult DeletePost(int threadID)
        {
            Thread thread = db.GetForumThread(threadID);
            //TODO: delete return value
            int rowsAffected = db.DeleteThread(thread);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int threadID)
        {
            return View(db.GetForumThread(threadID));
        }

        [HttpPost]
        public IActionResult EditPost(Thread thread)
        {
            int rowsAffected = db.EditThread(thread);

            return RedirectToAction("Index");
        }
    }
}