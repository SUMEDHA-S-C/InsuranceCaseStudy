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
            var PolicyTypes = db.tbl_policies.ToList();
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
                    ds.usp_addPolicies(policies.PolicyNumber, policies.PlanNumber, policies.InstallementPremium, policies.Insured, policies.SumAssured, policies.PolicyStatus, policies.PremiumMode, policies.PremiumDueDate, policies.Beneficiary, policies.Owner, policies.PolicyTerm);
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

        public ActionResult Update(int id)
        {
            using(var ds = new InsuranceEntities())
            {
                var data = ds.tbl_policies.Where(x => x.PolicyNumber == id).SingleOrDefault();
                if(data != null)
                {
                    return View(data);
                }
                else
                    return View();
            } 
        }

        [HttpPost]
        public ActionResult Update(int id, tbl_policies policy)
        {
            using(var ds = new InsuranceEntities())
            {
                try
                {
                    var data = ds.tbl_policies.Where(x => x.PolicyNumber == id).SingleOrDefault();
                    //data.PremiumMode = policy.PremiumMode;
                    data.PremiumDueDate = policy.PremiumDueDate;
                    data.PolicyStatus = policy.PolicyStatus;
                    ds.SaveChanges();
                    return RedirectToAction("ShowDetails");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult Delete(int id)
        {
            using( var ds = new InsuranceEntities())
            {
                ds.usp_deletePolicy(id);
                return RedirectToAction("ShowDetails");
            }
        }
    }
}