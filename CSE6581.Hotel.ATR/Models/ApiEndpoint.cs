using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CSE6581.Hotel.ATR.Models
{
    public class ApiEndpoint
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsSecured { get; set; }
    }
}
