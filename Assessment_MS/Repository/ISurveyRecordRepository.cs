using Assessment_MS.Models;

namespace Assessment_MS.Repository
{
    public interface ISurveyRecordRepository
    {
        Task<IEnumerable<SurveyRecord>> GetAllSurveyRecords();
        Task<SurveyRecord> GetSurveyRecordById(string id);
        Task<SurveyRecord> PostSurveyRecord(SurveyRecord surveyRecord);
    }
}
