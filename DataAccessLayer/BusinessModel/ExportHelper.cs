using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OfficeOpenXml;
using System.IO;

namespace DataAccessLayer.BusinessModel
{
    public class ExportHelper
    {
        string pathSaveFile;

        public ExportHelper(string path)
        {
            pathSaveFile = path;
        }

        public string PathSaveFile
        {
            get
            {
                return this.pathSaveFile;
            }
        }

        public void CreateHead(ExcelWorksheet ws)
        {
            ws.Cells[1,1].Value = "№Заказа";
            ws.Cells[1,2].Value = "Дата";
            ws.Cells[1,3].Value = "Артикул товара";
            ws.Cells[1,4].Value = "Название товара";
            ws.Cells[1,5].Value = "Кол-во реализ. ед";
            ws.Cells[1,6].Value = "Цена за шт";
            ws.Cells[1,7].Value = "Итого";
        }

        public bool ExportToExcel(List<DataAccessLayer.Report> ReportInfo)
        {
            if (ReportInfo.Count != 0)
            {
                using (var pck = new ExcelPackage(new FileInfo(this.pathSaveFile)))
                {
                    pck.Workbook.Worksheets.Delete("ReportInfo");
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ReportInfo");
                    ws.Cells["A1"].LoadFromCollection(ReportInfo, true);
                    CreateHead(ws);
                    for (int i = 0; i < ReportInfo.Count; i++)
                        ws.Cells["G" + (i + 2).ToString()].Formula = "= F" + (i + 2).ToString() + "*E" + (i + 2).ToString();

                    pck.Save();
                }
                return true;
            }
            else
                return false;
        }

    }
}
