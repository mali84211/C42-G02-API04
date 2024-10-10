namespace C42_G02_API04.Erorrs
{
    public class ApiVlidationErorrResponse : APIErorrResponse
    {
        public IEnumerable<string> Errors { get; set; } =new List<string>();
        public ApiVlidationErorrResponse():base(400)
        {

        }
    }
}
