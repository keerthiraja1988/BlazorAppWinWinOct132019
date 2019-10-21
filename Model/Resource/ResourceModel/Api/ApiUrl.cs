namespace ResourceModel.Api
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApiUrlResModel
    {
        public string Api { get; set; }

        public List<string> ApiUrls { get; set; } = new List<string>();
    }
}