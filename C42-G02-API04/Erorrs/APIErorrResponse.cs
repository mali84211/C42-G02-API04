namespace C42_G02_API04.Erorrs
{
    public class APIErorrResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public APIErorrResponse(int statuscode, string? message = null)
        {
            StatusCode = statuscode;
            Message = message?? GetDefaultMessageForStatusCode(statuscode);
        }
        private string? GetDefaultMessageForStatusCode(int statusCode) {
            var message = statusCode switch
            {
                400 => "a bad request , you have made",
                401=>"Authorized,you r not",
                404=>"Resource was not found",
                500=>"Server Erorr",
                _ =>null
            };
            return message;
        }
    }
}
