using FeedbackApp_WebAPI.DBAccess;
using FeedbackApp_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EvaluationController : Controller
    {
        [HttpGet("{pin}")]
        public IActionResult Get(string pin)
        {
            System.Console.WriteLine("Get PIN");
            try
            {
                var result = SQLiteFunctions.SelectEvaluation(pin);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "/r/nStackTrace:" + ex.StackTrace);
                return BadRequest("PIN inválido");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            System.Console.WriteLine("Get All");
            try
            {
                var result = SQLiteFunctions.SelectAllEvaluations();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "/r/nStackTrace:" + ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Evaluation evaluation)
        {
            System.Console.WriteLine("Post Evaluation");
            try
            {
                if (SQLiteFunctions.InsertEvaluation(evaluation) > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "/r/nStackTrace:" + ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Evaluation evaluation)
        {
            System.Console.WriteLine("Put Evaluation");
            try
            {
                if (SQLiteFunctions.UpdateEvaluation(evaluation) > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "/r/nStackTrace:" + ex.StackTrace);
                return BadRequest();
            }
        }
    }
}