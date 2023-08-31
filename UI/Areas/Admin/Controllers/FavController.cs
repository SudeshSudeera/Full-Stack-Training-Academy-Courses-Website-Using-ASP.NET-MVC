using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class FavController : BaseController
    {
        // GET: Admin/Fav
        FavBLL bll = new FavBLL();
        public ActionResult UpdateFav()
        {
            FavDTO dto = new FavDTO();
            dto = bll.GetFav();
            return View(dto);
;       }
        [HttpPost]
        public ActionResult UpdateFav(FavDTO model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if(model.FavImage != null)
                {
                    string favname = "";
                    HttpPostedFileBase postedFileFav = model.FavImage;
                    Bitmap FavImage = new Bitmap(postedFileFav.InputStream);
                    Bitmap resizeFavImage = new Bitmap(FavImage, 100, 100);
                    string ext = Path.GetExtension(postedFileFav.FileName);
                    if (ext == ".ico" || ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string favunique = Guid.NewGuid().ToString();
                        favname = favunique + postedFileFav.FileName;
                        resizeFavImage.Save(Server.MapPath("~/Areas/Admin/Content/FavImage/" + favname));
                        model.Fav = favname;
                    }
                    else
                        ViewBag.ProcessState = General.Messages.ExtensionError;
                }

                if (model.LogoImage != null)
                {
                    string logoname = "";
                    HttpPostedFileBase postedFileLogo = model.LogoImage;
                    Bitmap LogoImage = new Bitmap(postedFileLogo.InputStream);
                    Bitmap resizeLogoImage = new Bitmap(LogoImage, 100, 100);
                    string ext = Path.GetExtension(postedFileLogo.FileName);
                    if (ext == ".ico" || ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string logounique = Guid.NewGuid().ToString();
                        logoname = logounique + postedFileLogo.FileName;
                        resizeLogoImage.Save(Server.MapPath("~/Areas/Admin/Content/FavImage/" + logoname));
                        model.Logo = logoname;
                    }
                    else
                        ViewBag.ProcessState = General.Messages.ExtensionError;
                }
                FavDTO returndto = new FavDTO();
                returndto = bll.UpdateFav(model);
                if(model.FavImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/FavImage/" + returndto.Fav)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/FavImage/" + returndto.Fav));
                    }
                }
                if (model.LogoImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/FavImage/" + returndto.Logo)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/FavImage/" + returndto.Logo));
                    }
                }
                ViewBag.ProcessState = General.Messages.UpdateSuccess;
            }
            return View(model);
        }
    }
}