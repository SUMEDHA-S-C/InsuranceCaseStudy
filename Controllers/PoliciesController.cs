using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Insurance.Models;

namespace Insurance.Controllers
{
    public class PoliciesController : Controller
    {
        // GET: Policies
        public ActionResult ShowDetails()
        {
            var db = new InsuranceEntities();
            var PolicyTypes = db.tbl_policyType.ToList();
            return View(PolicyTypes);
        }

        public ActionResult AddDetails()
        {
            var ds = new InsuranceEntities();
            var insured = ds.usp_insured().ToList();
            var owner = ds.usp_owner().ToList();
            var beneficiary = ds.usp_beneficiary().ToList();
            var planNo = ds.tbl_policyType.ToList();

            ViewBag.PlanNumber = new SelectList(planNo, "PlanNumber", "PolicyName");
            ViewBag.Insured = new SelectList(insured );
            ViewBag.Owner = new SelectList(owner);
            ViewBag.Beneficiary = new SelectList(beneficiary);
            return View();
        }

        [HttpPost]
        public ActionResult AddDetails(tbl_policies policies)
        {
            var ds = new InsuranceEntities();
            var insured = ds.usp_insured().ToList();
            var owner = ds.usp_owner().ToList();
            var beneficiary = ds.usp_beneficiary().ToList();
            var planNo = ds.tbl_policyType.ToList();

            ViewBag.PlanNumber = new SelectList(planNo, "PlanNumber", "PolicyName");
            ViewBag.Insured = new SelectList(insured);
            ViewBag.Owner = new SelectList(owner);
            ViewBag.Beneficiary = new SelectList(beneficiary);

            if (ModelState.IsValid)
            {
                ds.tbl_policies.Add(policies);
                ds.SaveChanges();
                return RedirectToAction("ThankYou");
            }
            else
                return View(policies);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}