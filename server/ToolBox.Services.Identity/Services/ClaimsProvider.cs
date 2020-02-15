using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToolBox.Services.Identity.Services
{
    public class ClaimsProvider : IClaimsProvider
    {
        public async Task<IDictionary<string, string>> GetAsync(Guid userId)
        {
            // In furhter if any claims needed they should be added here
            // return await Task.FromResult(new Dictionary<string, string>
            // {
            //     ["custom_claim_1"] = "value1, value2, value3",
            //     ["custom_claim_2"] = "value1, value2, value3",
            // });
            return await Task.FromResult(new Dictionary<string, string>());
        }
    }
}