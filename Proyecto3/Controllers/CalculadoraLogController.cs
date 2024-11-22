using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web.Http;
using Proyecto3.DataAccess;

namespace Proyecto3.Controllers
{
    [RoutePrefix("api/logs")]
    public class CalculadoraLogController : ApiController
    {
        private readonly CalculadoraLogRepository _repository;

        public CalculadoraLogController()
        {
            _repository = new CalculadoraLogRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllLogs()
        {
            List<CalculadoraLog> logs = _repository.GetAllLogs();

            if (logs == null || logs.Count == 0)
                return NotFound();

            // Explicitly set JSON as response type
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, logs);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetLogById(int id)
        {
            CalculadoraLog log = _repository.GetLogById(id);

            if (log == null)
                return NotFound();

            // Explicitly set JSON as response type
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, log);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("suma")] // Ruta para obtener solo las operaciones de suma
        public IHttpActionResult GetLogsBySuma()
        {
            List<CalculadoraLog> logs = _repository.GetLogsByOperator("+  ");

            if (logs == null || logs.Count == 0)
                return NotFound();

            return Ok(logs); // Devuelve los registros de suma como JSON
        }

        [HttpGet]
        [Route("resta")] // Ruta para obtener solo las operaciones de resta
        public IHttpActionResult GetLogsByResta()
        {
            List<CalculadoraLog> logs = _repository.GetLogsByOperator("-  ");

            if (logs == null || logs.Count == 0)
                return NotFound();

            return Ok(logs); // Devuelve los registros de resta como JSON
        }

        [HttpGet]
        [Route("multiplicacion")] // Ruta para obtener solo las operaciones de multiplicación
        public IHttpActionResult GetLogsByMultiplicacion()
        {
            List<CalculadoraLog> logs = _repository.GetLogsByOperator("*  ");

            if (logs == null || logs.Count == 0)
                return NotFound();

            return Ok(logs); // Devuelve los registros de multiplicación como JSON
        }

        [HttpGet]
        [Route("division")] // Ruta para obtener solo las operaciones de división
        public IHttpActionResult GetLogsByDivision()
        {
            List<CalculadoraLog> logs = _repository.GetLogsByOperator("/  ");

            if (logs == null || logs.Count == 0)
                return NotFound();

            return Ok(logs); // Devuelve los registros de división como JSON
        }

        [HttpGet]
        [Route("factorizacion")] // Ruta para obtener solo las operaciones de factorización
        public IHttpActionResult GetLogsByFactorizacion()
        {
            List<CalculadoraLog> logs = _repository.GetLogsByOperator("!  ");

            if (logs == null || logs.Count == 0)
                return NotFound();

            return Ok(logs); // Devuelve los registros de factorización como JSON
        }

    }
}
