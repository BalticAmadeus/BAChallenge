using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Repository;
using BAChallengeWebServices.Utility;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace BAChallengeWebServices.Controllers
{
    public class ExcelExportController : ApiController
    {
        private readonly ResultlessActivityParticipantRepository _repository;

        public ExcelExportController(ResultlessActivityParticipantRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Function retrieves one Excel file  via ../ExcelExport/1 (GET)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>Excel file</returns>
        [ResponseType(typeof(ResultlessActivityParticipantModel))]
        [HttpGet]
        [Route("api/ExcelExport/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var activityParticipant = _repository.GetById(id);

            if (activityParticipant == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No Activity Participants found");
            }

            var excelExporter = new ActivityParticipantExcelExporter(activityParticipant);


                var result = new HttpResponseMessage()
                {
                    Content = new ByteArrayContent(excelExporter.FormatExcelFile())
                };

                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = $"{activityParticipant.Activity.Name}.xlsx"
                    };

                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/vnd.ms-excel");

                return result;
        }

        protected override void Dispose(bool disposing)
        { 
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
