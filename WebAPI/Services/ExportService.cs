using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ExportService
    {
        public string getCSV(List<CustomerAttributeModel> list)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Id, AttributeMaster, AttributeValuesCode, Description, ShortName, Parent, EffectiveDate, ValidUntil");
            foreach(var cust in list)
            {
                stringBuilder.AppendLine($"{cust.Id},{cust.AttributeMaster},{cust.AttributeValuesCode}, {cust.Description}, " +
                    $"{cust.ShortName}, {cust.Parent}, {cust.EffectiveDate}, {cust.ValidUntil}");
            }

            return stringBuilder.ToString();
        }

        private byte[] ConvertToByte(XLWorkbook workbook)
        {
            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            var content = stream.ToArray();
            return content;
        }

        public byte[] CreateFullExport()
        {
            var workbook = new XLWorkbook();
            workbook.Properties.Title = "Full Export";
            workbook.Properties.Author = "Chi Author";
            workbook.Properties.Subject = "Export Subject";
            workbook.Properties.Keywords = "Export, Chi, Blazor";

            CreateAuthorWorksheet(workbook);
            return ConvertToByte(workbook);
        }

        public void CreateAuthorWorksheet(XLWorkbook package)
        {
            var worksheet = package.Worksheets.Add("customerAttributeModels");

            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "AttributeMaster";
            worksheet.Cell(1, 3).Value = "AttributeValuesCode";
            worksheet.Cell(1, 4).Value = "Description";
            worksheet.Cell(1, 5).Value = "ShortName";
            worksheet.Cell(1, 6).Value = "Parent";
            worksheet.Cell(1, 7).Value = "EffectiveDate";
            worksheet.Cell(1, 8).Value = "ValidUntil";
            for(int i = 1; i <= CustomerAttribute.customerAttributeModels.Count; i++)
            {
                worksheet.Cell(i + 1, 1).Value = CustomerAttribute.customerAttributeModels[i - 1].Id;
                worksheet.Cell(i + 1, 2).Value = CustomerAttribute.customerAttributeModels[i - 1].AttributeMaster;
                worksheet.Cell(i + 1, 3).Value = CustomerAttribute.customerAttributeModels[i - 1].AttributeValuesCode;
                worksheet.Cell(i + 1, 4).Value = CustomerAttribute.customerAttributeModels[i - 1].Description;
                worksheet.Cell(i + 1, 5).Value = CustomerAttribute.customerAttributeModels[i - 1].ShortName;
                worksheet.Cell(i + 1, 6).Value = CustomerAttribute.customerAttributeModels[i - 1].Parent;
                worksheet.Cell(i + 1, 7).Value = CustomerAttribute.customerAttributeModels[i - 1].EffectiveDate;
                worksheet.Cell(i + 1, 8).Value = CustomerAttribute.customerAttributeModels[i - 1].ValidUntil;
            }
        }
    }
}
