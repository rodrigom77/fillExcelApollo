using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloApi.entity
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class OrganizationRootObject
    {
        [JsonProperty("organization")]
        public Organization1 Organization { get; set; }
    }

    [JsonObject("Organization")]
    public class Organization1
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("blog_url")]
        public string BlogUrl { get; set; }

        // ... other properties like angellist_url, linkedin_url, etc.

        [JsonProperty("primary_phone")]
        public PrimaryPhone1 PrimaryPhone { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        // ... additional properties like alexa_ranking, phone, founded_year, etc.

        [JsonProperty("suborganizations")]
        public List<SubOrganization> Suborganizations { get; set; }

        // ... other properties like seo_description, annual_revenue, etc.

        [JsonProperty("current_technologies")]
        public List<CurrentTechnology> CurrentTechnologies { get; set; }

        [JsonProperty("annual_revenue_printed")]
        public string AnnualRevenueRrinted { get; set; }

        [JsonProperty("annual_revenue")]
        public string AnnualRevenue { get; set; }

        [JsonProperty("estimated_num_employees")]
        public string EstimatedNumEmployees { get; set; }


        [JsonProperty("industry")]
               public string Industry { get; set; }

    }

    public class PrimaryPhone1
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class SubOrganization
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }
    }

    public class CurrentTechnology
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }

    // Additional nested classes can be added based on the JSON structure

}
