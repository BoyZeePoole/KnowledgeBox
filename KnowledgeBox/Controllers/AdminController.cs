using KnowledgeBox.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeBox.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private KnowledgeBoxEntities db = new KnowledgeBoxEntities();
        public ActionResult Index()
        {
            var items = db;
            return View(items);
        }

        public ActionResult Edit(int id = 0)
        {
            KnowledgeBox.Models.Item item = db.Items.Find(id);
            if (item != null)
                ViewBag.ContentType = new SelectList(db.ContentTypes.OrderBy(c => c.ContentType_Description), "ContentType_Id", "ContentType_Description", item.ContentType_Id);
            else
                ViewBag.ContentType = new SelectList(db.ContentTypes.OrderBy(c => c.ContentType_Description), "ContentType_Id", "ContentType_Description");

            if (item != null)
                ViewBag.Phase = new SelectList(db.Phases.OrderBy(c => c.Phase_Description), "Phase_Id", "Phase_Description", item.Phase_Id);
            else
                ViewBag.Phase = new SelectList(db.Phases.OrderBy(c => c.Phase_Description), "Phase_Id", "Phase_Description");

            ViewBag.Subject = new SelectList(db.Subjects.OrderBy(s => s.Subject_Description), "Subject_Id", "Subject_Description");
            ViewBag.Target = new SelectList(db.Targets.OrderBy(s => s.Target_Description), "Target_Id", "Target_Description");


            var itemSubject = db.ItemSubjects.Where(i => i.Item_Id == id);
            var arrSubject = itemSubject.Select(x => x.Subject.Subject_Id).ToArray();
            ViewBag.SubjectSelected = arrSubject;


            var itemTarget = db.ItemTargets.Where(i => i.Item_Id == id);
            var arrTarget = itemTarget.Select(x => x.Target.Target_Id).ToArray();
            ViewBag.TargetSelected = arrTarget;


            return View("Admin", item);
        }

        [HttpPost]
        public ActionResult Edit(Item item, string[] subject, string[] target, HttpPostedFileBase Item_FilePath, int id = 0)
        {
            if (ModelState.IsValid)
            {
                item.CreatedBy = 1; // Still need to tie this to a real user...
                item.Item_Date = DateTime.Today;
                if (id == 0)
                {
                    db.Entry(item).State = System.Data.EntityState.Added;
                    db.Items.Add(item);
                }
                else
                {
                    item.Item_Id = id;
                    db.Entry(item).State = System.Data.EntityState.Modified;
                }
                db.SaveChanges();
                int itemId = item.Item_Id;

                // we need to find a better way of doing this!

                var itemSubjects = db.ItemSubjects.Where(e => e.Item_Id == id);
                foreach (var itemSubject in itemSubjects)
                {
                    db.ItemSubjects.Remove(itemSubject);
                }
                var itemTargets = db.ItemTargets.Where(e => e.Item_Id == id);
                foreach (var itemTarget in itemTargets)
                {
                    db.ItemTargets.Remove(itemTarget);
                }
                //
                if (subject != null)
                {
                    foreach (var sub in subject)
                    {
                        db.ItemSubjects.Add(new ItemSubject { Item_Id = itemId, Subject_Id = Convert.ToInt32(sub) });
                    }
                }
                if (target != null)
                {
                    foreach (var tar in target)
                    {
                        db.ItemTargets.Add(new ItemTarget { Item_Id = itemId, Target_Id = Convert.ToInt32(tar) });
                    }
                }
                db.SaveChanges();
                //return RedirectToAction("Edit", new { id = itemId });
                return RedirectToAction("Index");
            }

            ViewBag.ContentType = new SelectList(db.ContentTypes.OrderBy(c => c.ContentType_Description), "ContentType_Id", "ContentType_Description");
            ViewBag.Phase = new SelectList(db.Phases.OrderBy(c => c.Phase_Description), "Phase_Id", "Phase_Description");
            ViewBag.Subject = new SelectList(db.Subjects.OrderBy(s => s.Subject_Description), "Subject_Id", "Subject_Description");
            ViewBag.Target = new SelectList(db.Targets.OrderBy(s => s.Target_Description), "Target_Id", "Target_Description");



            ViewBag.SubjectSelected = (subject != null) ? subject : new string[] { };
            ViewBag.TargetSelected = (target != null) ? target : new string[] { }; ;
            //return RedirectToAction("Index");
            return View("Admin", item);
        }

        
        /// <summary>
        /// Subject Actions
        /// </summary>
        /// <returns></returns>
        public ActionResult Subject()
        {
            var subjects = db.Subjects; 
            return View("Subject", subjects);
        }
        public ActionResult EditSubject(int id = 0)
        {
            KnowledgeBox.Models.Subject item = db.Subjects.Find(id);
            return View("EditSubject", item);
        }
        [HttpPost]
        public ActionResult EditSubject(Subject subject, int id=0)
        {
            if (ModelState.IsValid)
            {
                subject.CreatedBy = 1;
                subject.Subject_Date = DateTime.Today;
                if (id == 0)
                {
                    db.Entry(subject).State = System.Data.EntityState.Added;
                    db.Subjects.Add(subject);
                }
                else
                {
                    subject.Subject_Id= id;
                    db.Entry(subject).State = System.Data.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Subject");
            }
            return View("EditSubject", subject);
        }

        /// <summary>
        /// Target Actions
        /// </summary>
        /// <returns></returns>
        public ActionResult Target()
        {
            var targets = db.Targets;
            return View("Target", targets);
        }
        public ActionResult EditTarget(int id = 0)
        {
            KnowledgeBox.Models.Target item = db.Targets.Find(id);
            return View("EditTarget", item);
        }
        [HttpPost]
        public ActionResult EditTarget(Target target, int id = 0)
        {
            if (ModelState.IsValid)
            {
                target.CreatedBy = 1;
                target.Target_Date = DateTime.Today;
                if (id == 0)
                {
                    db.Entry(target).State = System.Data.EntityState.Added;
                    db.Targets.Add(target);
                }
                else
                {
                    target.Target_Id = id;
                    db.Entry(target).State = System.Data.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Target");
            }
            return View("EditTarget", target);
        }

        /// <summary>
        /// Phase Actions
        /// </summary>
        /// <returns></returns>
        public ActionResult Phase()
        {
            var phases = db.Phases;
            return View("Phase", phases);
        }
        public ActionResult EditPhase(int id = 0)
        {
            KnowledgeBox.Models.Phase item = db.Phases.Find(id);
            return View("EditPhase", item);
        }
        [HttpPost]
        public ActionResult EditPhase(Phase phase, int id = 0)
        {
            if (ModelState.IsValid)
            {
                phase.CreatedBy = 1;
                phase.Phase_Date = DateTime.Today;
                if (id == 0)
                {
                    db.Entry(phase).State = System.Data.EntityState.Added;
                    db.Phases.Add(phase);
                }
                else
                {
                    phase.Phase_Id = id;
                    db.Entry(phase).State = System.Data.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Phase");
            }
            return View("EditPhase", phase);
        }
        /// <summary>
        /// ContentType Actions
        /// </summary>
        /// <returns></returns>
        public ActionResult ContentType()
        {
            var contentTypes = db.ContentTypes;
            return View("ContentType", contentTypes);
        }
        public ActionResult EditContentType(int id = 0)
        {
            KnowledgeBox.Models.ContentType item = db.ContentTypes.Find(id);
            return View("EditContentType", item); 
        }
        [HttpPost]
        public ActionResult EditContentType(ContentType contentType, HttpPostedFileBase ContentType_Thumbnail, int id = 0)
        {
            if (ModelState.IsValid)
            {
                contentType.CreatedBy = 1;
                contentType.ContentType_Date = DateTime.Today;
                if (id == 0)
                {
                    db.Entry(contentType).State = System.Data.EntityState.Added;
                    db.ContentTypes.Add(contentType);
                }
                else
                {
                    contentType.ContentType_Id = id;
                    db.Entry(contentType).State = System.Data.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("ContentType");
            }
            return View("EditContentType", contentType);            
        }

        public ActionResult SearchResult(int phaseId, int subjectId, string pageLink)
        {
            //var items = new List<Item>();
            var items = from i in db.Items
                         from s in i.ItemSubjects
                         where s.Subject_Id == subjectId
                         && i.Phase_Id == phaseId
                         select i;
            
            var phaseTitle = db.Phases.Where(phase => phase.Phase_Id == phaseId).SingleOrDefault().Phase_Description;
            var subjectTitle = db.Subjects.Where(subject => subject.Subject_Id == subjectId).SingleOrDefault().Subject_Description;
            var subjectImage = db.Subjects.Where(subject => subject.Subject_Id == subjectId).SingleOrDefault().Subject_Thumbnail;
            SearchResultModel srm = new SearchResultModel();
            srm.Title = phaseTitle;
            srm.Subject = subjectTitle;
            srm.Items = items;
            srm.PhaseLink = pageLink;
            srm.ImageName = subjectImage;
            return View(srm);
        }
    }
}
