using Assessment_MS.Models;
using Assessment_MS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_MS.Controllers
{
    public class SurveyController : Controller
    {
        public ISurveyRecordRepository _surveyRecordRepository { get; }

        public SurveyController(ISurveyRecordRepository surveyRecordRepository)
        {
            _surveyRecordRepository = surveyRecordRepository;
        }


        public IActionResult Create()
        {
            var surveyRecord = new SurveyRecord();
            
            return View(surveyRecord);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyRecord surveyRecord)
        {
            await _surveyRecordRepository.PostSurveyRecord(surveyRecord);

            return RedirectToAction("Index", "Home");
        }

 


    }


}
