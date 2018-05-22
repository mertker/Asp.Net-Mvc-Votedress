using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Votedress.BusinessLayer;
using Votedress.Entities;
using Votedress.Entities.Messages;
using Votedress.Entities.Modellerim;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.Modellerim.GirisEkrainModellerim;
using Votedress.Entities.Modellerim.KayıtolEkranıModellerim;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;


namespace Votedress.WebApp.Controllers
{
    public class AccountController : Controller
    {

        // GET: Giris
        public ActionResult Giris(string url)
        {

            TempData["url"] = url;

            return View();
        }
        [HttpPost]
        public ActionResult Giris(Giris GirisBilgileri)
        {
            if (ModelState.IsValid)
            {
                VotedressUserManager userManager = new VotedressUserManager();
                UserManagerResult res = new UserManagerResult();

                res = userManager.GirisKontrol(GirisBilgileri);

                if (res.Errors.Count > 0)
                {

                    if (res.Errors.Find(x => x.Code == Entities.Messages.ErrorMessageCode.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "Activasyon kodu gönder";
                    }


                    for (int i = 0; i < res.Errors.Count; i++)
                    {
                        ModelState.AddModelError(res.HataNerece[i].ToString(), res.Errors[i].Message);
                    }

                    return View(GirisBilgileri);
                }

                Session["login"] = res.User;

                if (TempData["url"] == null)
                {

                    if (res.User.Role != "kurumsal")
                    {
                        return RedirectToAction("Index", "Oylama");
                    }

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    string url = TempData["url"].ToString();
                    return Redirect(url);
                }
            }
            else
            {
                return View(GirisBilgileri);

            }
        }




        public ActionResult HesapOlustur()
        {
            return View(new HesapOlusturViewModel());
        }

        [HttpGet]
        [OutputCache(Duration = 999999999)]
        public JsonResult SehirleriGetir()
        {
            CityManager cityManager = new CityManager();
            List<City> Sehirler = cityManager.SehirleriGetir();

            var JsonModel = new
            {
                Sehirler = Sehirler.Select(x => new
                {

                    CityID = x.CityID,
                    CountyID = x.CountryID,
                    CityName = x.CityName,
                    PlateNo = x.PlateNo,
                    PhoneCode = x.PhoneCode

                }),

            };

            return Json(JsonModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IlceleriGetir(int CityID)
        {
            CityManager cityManager = new CityManager();
            List<County> Ilceler = cityManager.IlceleriGetir(CityID);

            var JsonModel = new
            {
                Ilceler = Ilceler.Select(x => new
                {
                    CountyID=x.CountyID,
                    CountyName=x.CountyName,                  
                }),

            };

            return Json(JsonModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MahalleleriGetir(int CountyID)
        {
            CityManager cityManager = new CityManager();
            List<Neighborhood> Mahalleler = cityManager.MahalleleriGetir(CountyID);

            var JsonModel = new
            {
                Mahalleler = Mahalleler.Select(x => new
                {
                    NeighborhoodID=x.NeighborhoodID,
                    NeighborhoodName=x.NeighborhoodName
                }),

            };

            return Json(JsonModel, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult HesapOlustur(HesapOlusturViewModel veriler)
        {
            VotedressUserManager userManager = new VotedressUserManager();
            if (veriler.BireyselHesap != null)
            {
                if (ModelState.IsValid)
                {
                    UserManagerResult res = userManager.BireyselKullaniciKayit(veriler.BireyselHesap);

                    if (res.Errors.Count > 0)
                    {
                        for (int i = 0; i < res.Errors.Count; i++)
                        {
                            ModelState.AddModelError(res.HataNerece[i].ToString(), res.Errors[i].Message);
                        }

                        return PartialView("_BireyselHesapOlustur", veriler);
                    }

                    return Json(new { redirectTo = Url.Action("Giris", "Account") });

                }
                else
                {
                    PartialViewResult aa = new PartialViewResult();
                    aa = PartialView("_BireyselHesapOlustur");

                    var deneme = ConvertToString(aa, ControllerContext);



                    return Json(new { PartialView = deneme, Nereden = "Bireysel" });
                }

            }
            else
            {
                veriler.BireyselHesap = new BireyselHesapKayit();

                if (ModelState.IsValid)
                {
                    UserManagerResult res = userManager.KurumsalKullaniciKayit(veriler.KurumsalHesap);

                    if (res.Errors.Count > 0)
                    {
                        for (int i = 0; i < res.Errors.Count; i++)
                        {
                            ModelState.AddModelError(res.HataNerece[i].ToString(), res.Errors[i].Message);
                        }

                        return PartialView("_KurumsalHesapOlustur", veriler);
                    }

                    return Json(new { redirectTo = Url.Action("Giris", "Account") });


                }
                else
                    {
                  
                    PartialViewResult aa = new PartialViewResult();
                    aa = PartialView("_KurumsalHesapOlustur");

                    var deneme = ConvertToString(aa,ControllerContext);



                    return Json(new { PartialView = deneme, Nereden = "Kurumsal" });
                }



            }

        }
        public string ConvertToString(PartialViewResult partialView,
                                           ControllerContext controllerContext)
        {
            using (var sw = new StringWriter())
            {
                partialView.View = ViewEngines.Engines
                  .FindPartialView(controllerContext, partialView.ViewName).View;

                var vc = new ViewContext(
                  controllerContext, partialView.View, partialView.ViewData, partialView.TempData, sw);
                partialView.View.Render(vc, sw);

                var partialViewString = sw.GetStringBuilder().ToString();

                return partialViewString;
            }
        }

        public ActionResult HesapAktive(Guid id)
        {
            VotedressUserManager userManager = new VotedressUserManager();
            UserManagerResult res = userManager.HesapAktiveEt(id);

            if (res.Errors.Count > 0)
            {
                TempData["errors"] = res.Errors;
                return RedirectToAction("AktifederkenHata");
            }

            return RedirectToAction("HesapAktifEdildi");
        }

        public ActionResult HesapAktifEdildi()
        {
            return View();
        }

        public ActionResult YetkisizGiris()
        {
            return View();
        }


        public ActionResult AktifederkenHata()
        {
            List<ErrorMessageObj> errors = null;
            if (TempData["errors"] != null)
            {
                errors = TempData["errors"] as List<ErrorMessageObj>;

            }
            return View(errors);
        }


        public ActionResult LogOut()
        {

            Session.Clear();


            return RedirectToAction("Giris", "Account");
        }
    }
}