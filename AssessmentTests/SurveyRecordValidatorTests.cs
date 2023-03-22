using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
using Assessment_MS.Models;
using Assessment_MS.Validations;
using System.Linq;

namespace AssessmentTests
{

    public class SurveyRecordValidatorTests
    {
        private SurveyRecordValidator surveyRecordValidator;

        public SurveyRecordValidatorTests()
        {
            surveyRecordValidator = new SurveyRecordValidator();
        }


        #region "Values that should pass validation"
            string _FullName = "Fred Bloggs";
            string _EmailAddress = "fred.bloggs@fb.com";
            bool _BrightnessAcceptance = true;
            int _BrightnessLevel = 5;
            string _AddressLine1 = "1 Some street";
            string _AddressLine2 = "some area";
            string _Town = "Sometown";
            string _County = "SomeCounty";
            string _Postcode = "AA11 1AA";
        #endregion


        [Theory]
        [InlineData(null,false)]
        [InlineData("", false)]
        [InlineData("1234567890123456789012345678901234567890123456789011", false)]
        [InlineData("Fred Blogs", true)]
        public void TestFullName(string fullName, bool expectedResult)
        {

            SurveyRecord surveyRecord = new(fullName, 
                                            _EmailAddress, 
                                            _BrightnessAcceptance, 
                                            _BrightnessLevel, 
                                            _AddressLine1, 
                                            _AddressLine2, 
                                            _Town, 
                                            _County, 
                                            _Postcode);
            var result = surveyRecordValidator.TestValidate(surveyRecord);
            Assert.True(result.IsValid == expectedResult);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", false)]
        [InlineData("aaaaaaa", false)]
        [InlineData("Fred.Blogs@tezt.com", true)]
        public void TestEmail(string emailAddress, bool expectedResult)
        {

            SurveyRecord surveyRecord = new(_FullName,
                                            emailAddress,
                                            _BrightnessAcceptance,
                                            _BrightnessLevel,
                                            _AddressLine1,
                                            _AddressLine2,
                                            _Town,
                                            _County,
                                            _Postcode);
            var result = surveyRecordValidator.TestValidate(surveyRecord);
            Assert.True(result.IsValid == expectedResult);
        }


        [Theory]
        [InlineData(null, false)]
        [InlineData(false, true)]
        [InlineData(true, true)]
        public void TestBrightnessAcceptance(bool? brightnessAcceptance, bool expectedResult)
        {

            SurveyRecord surveyRecord = new(_FullName,
                                            _EmailAddress,
                                            brightnessAcceptance,
                                            _BrightnessLevel,
                                            _AddressLine1,
                                            _AddressLine2,
                                            _Town,
                                            _County,
                                            _Postcode);
            var result = surveyRecordValidator.TestValidate(surveyRecord);
            Assert.True(result.IsValid == expectedResult);
        }



        [Theory]
        [InlineData(null, false)]
        [InlineData(-1, false)]
        [InlineData(11, false)]
        [InlineData(8, true)]
        public void TestBrightnessLevel(int? brightnessLevel, bool expectedResult)
        {

            SurveyRecord surveyRecord = new(_FullName,
                                            _EmailAddress,
                                            _BrightnessAcceptance,
                                            brightnessLevel,
                                            _AddressLine1,
                                            _AddressLine2,
                                            _Town,
                                            _County,
                                            _Postcode);
            var result = surveyRecordValidator.TestValidate(surveyRecord);
            Assert.True(result.IsValid == expectedResult);
        }







    }
}