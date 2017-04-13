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
    /// <summary>
    /// Excel file exporter for ActivityParticipant model.
    /// </summary>
    public class ActivityParticipantExcelExporter
    {
        private readonly ResultlessActivityParticipantModel _activityParticipant;
        private const int HeaderRow = 5;

        /// <summary>
        /// Takes in activityParticipant object, which the exporter will parse.
        /// </summary>
        /// <param name="activityParticipant"></param>
        public ActivityParticipantExcelExporter(ResultlessActivityParticipantModel activityParticipant)
        {
            _activityParticipant = activityParticipant;
        }

        /// <summary>
        /// Formats to excel the activityParticipant object.
        /// </summary>
        /// <returns>Byte array, full of information to put into excel file</returns>
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

        /// <summary>
        /// Creates subheader for excel worksheet at specified coordinate: formats the cell and inserts a given value.
        /// </summary>
        /// <param name="worksheet">ExcelWorksheet</param>
        /// <param name="cellCoordinate">Coordinate</param>
        /// <param name="value">Value to insert.</param>
        private static void CreateSubHeader(ExcelWorksheet worksheet, string cellCoordinate, string value)
        {
            var header = worksheet.Cells[cellCoordinate];
            CenterCells(header);
            AddBorders(header, ExcelBorderStyle.Medium);
            header.Value = value;
        }

        /// <summary>
        /// Adds set borderstyle to given cell range.
        /// </summary>
        /// <param name="range">Cell range, to which add borders.</param>
        /// <param name="borderStyle">Style to which set the borders.</param>
        private static void AddBorders(ExcelRange range, ExcelBorderStyle borderStyle)
        {
            range.Style.Border.Bottom.Style = borderStyle;
            range.Style.Border.Top.Style = borderStyle;
            range.Style.Border.Left.Style = borderStyle;
            range.Style.Border.Right.Style = borderStyle;
        }


        /// <summary>
        /// Centers the cells in a given cell range.
        /// </summary>
        /// <param name="range">Cells, which to center.</param>
        private static void CenterCells(ExcelRange range)
        {
            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        /// <summary>
        /// Colors the given cell range according to branch (using BAChallenge various branch colors).
        /// </summary>
        /// <param name="range">Cells, which to color.</param>
        /// <param name="branch">Branch, which is used to change the color accordingly/</param>
        private static void FillByBranch(ExcelRange range, ActivityBranch branch)
        {

            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            switch (branch)
            {
                case ActivityBranch.Melyno:
                    range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
                    break;
                case ActivityBranch.Naujo:
                    range.Style.Fill.BackgroundColor.SetColor(Color.SeaGreen);
                    break;
                case ActivityBranch.Savo:
                    range.Style.Fill.BackgroundColor.SetColor(Color.IndianRed);
                    break;
                case ActivityBranch.Seno:
                    range.Style.Fill.BackgroundColor.SetColor(Color.DeepSkyBlue);
                    break;
                default:
                    range.Style.Fill.BackgroundColor.SetColor(Color.White);
                    break;
            }
        }
    }
}