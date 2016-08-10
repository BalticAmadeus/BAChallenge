using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace BAChallengeWebServices.Utility
{
    public class ActivityParticipantExcelExporter
    {
        private readonly ResultlessActivityParticipantModel _activityParticipant;
        private const int HeaderRow = 5;

        public ActivityParticipantExcelExporter(ResultlessActivityParticipantModel activityParticipant)
        {
            _activityParticipant = activityParticipant;
        }

        public byte[] FormatExcelFile()
        {
            using (var excelPackage = new ExcelPackage(new MemoryStream()))
            {

                var worksheet = excelPackage.Workbook.Worksheets.Add("Dalyvių sąrašas");

                var title = worksheet.Cells[$"B{HeaderRow - 3}:E{HeaderRow - 2}"];

                CenterCells(title);
                title.Style.Font.Size = 24f;
                AddBorders(title, ExcelBorderStyle.Thin);
                FillByBranch(title, _activityParticipant.Activity.Branch);
                title.Value = _activityParticipant.Activity.Name;
                title.AutoFitColumns();
                title.Merge = true;

                var infoHeader = worksheet.Cells[$"B{HeaderRow - 1}:E{HeaderRow - 1}"];
                CenterCells(infoHeader);
                AddBorders(infoHeader, ExcelBorderStyle.Thin);
                infoHeader.Value = $"Dalyvių sąrašas (sudarytas {DateTime.Now.ToString("yyyy-MM-dd")})";
                infoHeader.Style.WrapText = true;
                infoHeader.Merge = true;

                CreateSubHeader(worksheet, $"B{HeaderRow}", "Id");
                CreateSubHeader(worksheet, $"C{HeaderRow}", "Vardas");
                CreateSubHeader(worksheet, $"D{HeaderRow}", "Pavardė");
                CreateSubHeader(worksheet, $"E{HeaderRow}", "Informacija");


                var collectionCells = worksheet.Cells[$"B{HeaderRow + 1}:E{_activityParticipant.Participants.Count + HeaderRow}"];


                worksheet.Column(5).Width = 40;
                CenterCells(collectionCells);

                collectionCells.LoadFromCollection(_activityParticipant.Participants);
                collectionCells.Style.WrapText = true;
                
                AddBorders(collectionCells, ExcelBorderStyle.Thin);

                return excelPackage.GetAsByteArray();
            }

        }

        private static void CreateSubHeader(ExcelWorksheet worksheet, string cellCoordinate, string value)
        {
            var header = worksheet.Cells[cellCoordinate];
            CenterCells(header);
            AddBorders(header, ExcelBorderStyle.Medium);
            header.Value = value;
        }

        private static void AddBorders(ExcelRange range, ExcelBorderStyle borderStyle)
        {
            range.Style.Border.Bottom.Style = borderStyle;
            range.Style.Border.Top.Style = borderStyle;
            range.Style.Border.Left.Style = borderStyle;
            range.Style.Border.Right.Style = borderStyle;
        }

        private static void CenterCells(ExcelRange range)
        {
            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        private static void FillByBranch(ExcelRange range, ActivityBranch branch)
        {

            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            switch (branch)
            {
                case ActivityBranch.Brain:
                    range.Style.Fill.BackgroundColor.SetColor(Color.Khaki);
                    break;
                case ActivityBranch.Games:
                    range.Style.Fill.BackgroundColor.SetColor(Color.SeaGreen);
                    break;
                case ActivityBranch.Sports:
                    range.Style.Fill.BackgroundColor.SetColor(Color.IndianRed);
                    break;
                case ActivityBranch.Team:
                    range.Style.Fill.BackgroundColor.SetColor(Color.DeepSkyBlue);
                    break;
                default:
                    range.Style.Fill.BackgroundColor.SetColor(Color.White);
                    break;
            }
        }
    }
}