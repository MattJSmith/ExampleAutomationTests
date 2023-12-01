using EnsekExample.Tools.ApiFactory;

namespace EnsekExample.Domains.TestReset
{
    /// <summary>
    /// Helper methods for Reset api calls.
    /// </summary>
    internal class ResetHelper //Future Could make public/ We could seperate the entire domain folder structure into a new project that other teams can use.
    {
        private readonly ApiHelper apiHelper;

        internal ResetHelper()
        {
            apiHelper = new ApiHelper();
        }

        internal async Task<ResetApiResponse> ResetData()
        {
            var body = new resetRequest
            {
                access_token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTcwMTQzMTMxNCwianRpIjoiODAyNzRmZDQtOGI4NS00ODdhLWE2ZTMtMWE4MDBhMjA4NjE5IiwidHlwZSI6ImFjY2VzcyIsInN1YiI6InRlc3QiLCJuYmYiOjE3MDE0MzEzMTQsImV4cCI6MTcwMTQzMjIxNCwicGFzc3dvcmQiOiJ0ZXN0aW5nIn0.XQTkVxVJOm5O-kSFi4C90WgbT-1DdBJqUEj-9OilMeY"
            };
            //Fails with and without the access_token retrieved from login method.
            //Future: If this token is needed for api calls, I would login once for all tests and store the access_token to reduce api calls needed for tests.
            return (await apiHelper.SendPostRequest<resetRequest, ResetApiResponse>("reset", body)).content ?? throw new Exception("Reset Api request returned null");
        }

    }
}
