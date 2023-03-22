using Assessment_MS.Data;
using Assessment_MS.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment_MS.Repository
{
    public class SurveyRecordRepository : ISurveyRecordRepository
    {

        public IConfiguration _configuration { get; }

        public SurveyRecordRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<SurveyRecord>> GetAllSurveyRecords()
        {
            List<SurveyRecord> surveyRecords = new();

            var connectionString = _configuration.GetConnectionString("AssessmentDB");

            using (var appDbContext = new AppDbContext(connectionString))
            {
                if (appDbContext.SurveyRecords != null)
                {
                    surveyRecords = await appDbContext.SurveyRecords.ToListAsync();
                }
            }
            return surveyRecords;
        }

        public async Task<SurveyRecord> GetSurveyRecordById(string id)
        {
            var connectionString = _configuration.GetConnectionString("AssessmentDB");

            SurveyRecord? surveyRecord = null;

            using (var appDbContext = new AppDbContext(connectionString))
            {
                if (appDbContext.SurveyRecords != null)
                {
                    surveyRecord = await appDbContext.SurveyRecords.FindAsync(id);
                }
            }
            return surveyRecord;
        }

        public async Task<SurveyRecord> PostSurveyRecord(SurveyRecord surveyRecord)
        {
            var connectionString = _configuration.GetConnectionString("AssessmentDB");

            using (var appDbContext = new AppDbContext(connectionString))
            {
                if (appDbContext.SurveyRecords != null)
                {
                    await appDbContext.SurveyRecords.AddAsync(surveyRecord);
                    await appDbContext.SaveChangesAsync();
                }
            }
            return await GetSurveyRecordById(surveyRecord.Id);
        }
    }
}
