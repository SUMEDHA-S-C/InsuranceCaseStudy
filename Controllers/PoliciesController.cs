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
                try
                {
                    ds.tbl_policies.Add(policies);
                    ds.SaveChanges();
                    Session["sumAssured"] = Convert.ToDouble(policies.SumAssured);
                    Session["planNumber"] = Convert.ToInt32(policies.PlanNumber);
                    Session["policyTerm"] = Convert.ToInt32(policies.PolicyTerm);
                    Session["owner"] = policies.Owner.ToString();
                    Session["insured"] = policies.Insured.ToString();
                    Session["benificiary"] = policies.Beneficiary.ToString();
                    Session["premium"] = Convert.ToDouble(policies.InstallementPremium);

                    return RedirectToAction("ThankYou", policies);
                }
                catch
                {
                    return View(policies);
                } 
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