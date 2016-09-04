using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;
using DataAccessLayer;
using Microsoft.Reporting.WebForms;
using System.IO;
using OfficeOpenXml;
using DataAccessLayer.IRapository;
using DataAccessLayer.MSSQLRepository;
using PagedList;
using System.Configuration;
using System.Net.Configuration;
using DataAccessLayer.BusinessModel;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IOrderDetailRepository repository;
        MailSender mailSender;
        ExportHelper exportHelper;

        public HomeController()
        {
            repository = new MSSQLOrderDetailRepository();
            mailSender = new MailSender();
        }


        public ActionResult Index(int? page, string submitButton, string startTime, string finishTime, string email)
        {
            exportHelper = new ExportHelper(HttpContext.Server.MapPath("~/Temp/") + "ReportExcel.xlsx");

            if ((String.IsNullOrEmpty(startTime)) || (String.IsNullOrEmpty(finishTime)))
            {
                startTime = "04/07/1996";
                finishTime = "04/10/1996";
            }

            var reportInfo = new List<DataAccessLayer.Report>();
            reportInfo = repository.GetOrderDetailByPeriod(Convert.ToDateTime(startTime), Convert.ToDateTime(finishTime));
            
            if (submitButton == "Отправить")
                if (exportHelper.ExportToExcel(reportInfo.ToList()))
                {
                    mailSender.SendMailWithAttached(email, exportHelper.PathSaveFile);
                    TempData["msg"] = "Вам был отправлен отчет за выбранный период";
                }
                else
                    TempData["msg"] = "В данный период не было заказов. Выберите другие даты. Пример 08/08/1997 - 04/10/1998";
            else
                    TempData["msg"] = "Отчет за период с " + startTime + " по " + finishTime;

            return View(reportInfo.ToList());
        }

    }
}