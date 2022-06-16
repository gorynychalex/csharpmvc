using EPPlus.WebSampleMvc.NetCore.Models.HtmlExport;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EPPlus.WebSampleMvc.NetCore.Controllers
{
    public class HtmlExportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private const string ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        [HttpGet]
        public IActionResult ExportTable1()
        {
            var model = new ExportTable1Model();
            model.SetupSampleData(0);
            model.TableStyle = "Dark1";
            return View(model);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ExportTable1(ExportTable1Model model)
        {
            if(!Enum.TryParse(model.TableStyle, out TableStyles ts))
            {
                ts = TableStyles.Dark1;
            }

            
            ViewData["TableStyle"] = TableStyles.Dark1.ToString();
            model.SetupSampleData(model.Theme,ts);
            
            // if(model.GetWorkbook)
            // {
            //     return File(model.WorkbookBytes, ContentType, "EPPlusHtmlSample1.xlsx");
            // }
            return File(model.WorkbookBytes, ContentType, "EPPlusHtmlSample1.xlsx");

            // return View(model);
        }
    }
}
