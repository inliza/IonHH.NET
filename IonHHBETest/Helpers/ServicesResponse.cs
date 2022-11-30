namespace IonHHBETest.Helpers
{
    public class ServicesResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public int Code { get; set; }

        public ServicesResponse(int code, string message, object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
}
}
