using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private ExportService _service;
        private string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private string fileName = "customerAttributeModels.xlsx";

        public ExportController(ExportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult DownloadExport()
        {
            return File(_service.CreateFullExport(), contentType, fileName);
        }
    }
}
