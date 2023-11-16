using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ApolloApi.entity
{
    public class PeopleEnrichmentRootObject
    {
        public PersonPeopleMatch Person { get; set; }
    }

    [JsonObject("Person")]
    public class PersonPeopleMatch
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string LinkedinUrl { get; set; }
        public string Title { get; set; }
        public string EmailStatus { get; set; }
        public string PhotoUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public double? ExtrapolatedEmailConfidence { get; set; }
        public string Headline { get; set; }
        public string Email { get; set; }
        public string OrganizationId { get; set; }
        public List<EmploymentHistoryPeopleMatch> EmploymentHistory { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Organization Organization { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public object IntentStrength { get; set; }
        public bool ShowIntent { get; set; }
        public bool RevealedForCurrentTeam { get; set; }
        public List<string> Departments { get; set; }
        public List<string> Subdepartments { get; set; }
        public List<string> Functions { get; set; }
        public string Seniority { get; set; }
    }
    [JsonObject("EmploymentHistory")]
    public class EmploymentHistoryPeopleMatch
    {
        public string Id { get; set; }
        public object CreatedAt { get; set; }
        public bool Current { get; set; }
        public object Degree { get; set; }
        public object Description { get; set; }
        public object Emails { get; set; }
        public string EndDate { get; set; }
        public object GradeLevel { get; set; }
        public object Kind { get; set; }
        public object Major { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public object RawAddress { get; set; }
        public string StartDate { get; set; }
        public string Title { get; set; }
        public object UpdatedAt { get; set; }
        public string Key { get; set; }
    }

    public class Organization
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("blog_url")]
        public string BlogUrl { get; set; }

        [JsonProperty("angellist_url")]
        public string AngellistUrl { get; set; }

        [JsonProperty("linkedin_url")]
        public string LinkedinUrl { get; set; }

        [JsonProperty("twitter_url")]
        public string TwitterUrl { get; set; }

        [JsonProperty("facebook_url")]
        public string FacebookUrl { get; set; }

        [JsonProperty("primary_phone")]
        public PrimaryPhone PrimaryPhone { get; set; }

        [JsonProperty("languages")]
        public List<object> Languages { get; set; }

        [JsonProperty("alexa_ranking")]
        public int AlexaRanking { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("linkedin_uid")]
        public string LinkedinUid { get; set; }

        [JsonProperty("founded_year")]
        public int FoundedYear { get; set; }

        [JsonProperty("publicly_traded_symbol")]
        public string PubliclyTradedSymbol { get; set; }

        [JsonProperty("publicly_traded_exchange")]
        public string PubliclyTradedExchange { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("crunchbase_url")]
        public string CrunchbaseUrl { get; set; }

        [JsonProperty("primary_domain")]
        public string PrimaryDomain { get; set; }

        [JsonProperty("sanitized_phone")]
        public string SanitizedPhone { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("keywords")]
        public List<object> Keywords { get; set; }

        [JsonProperty("estimated_num_employees")]
        public int EstimatedNumEmployees { get; set; }

        [JsonProperty("industries")]
        public List<string> Industries { get; set; }

        [JsonProperty("secondary_industries")]
        public List<object> SecondaryIndustries { get; set; }

        [JsonProperty("snippets_loaded")]
        public bool SnippetsLoaded { get; set; }

        [JsonProperty("industry_tag_id")]
        public string IndustryTagId { get; set; }

        [JsonProperty("industry_tag_hash")]
        public Dictionary<string, string> IndustryTagHash { get; set; }

        [JsonProperty("retail_location_count")]
        public int RetailLocationCount { get; set; }

        [JsonProperty("raw_address")]
        public string RawAddress { get; set; }

        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("owned_by_organization_id")]
        public string OwnedByOrganizationId { get; set; }

        [JsonProperty("suborganizations")]
        public List<object> Suborganizations { get; set; }

        [JsonProperty("num_suborganizations")]
        public int NumSuborganizations { get; set; }

        [JsonProperty("seo_description")]
        public string SeoDescription { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("annual_revenue_printed")]
        public string AnnualRevenuePrinted { get; set; }

        [JsonProperty("annual_revenue")]
        public double AnnualRevenue { get; set; }

        [JsonProperty("technology_names")]
        public List<object> TechnologyNames { get; set; }

        [JsonProperty("current_technologies")]
        public List<object> CurrentTechnologies { get; set; }

        [JsonProperty("org_chart_root_people_ids")]
        public List<string> OrgChartRootPeopleIds { get; set; }
    }

    public class PrimaryPhone
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("country_code_added_from_hq")]
        public bool CountryCodeAddedFromHq { get; set; }
    }

    public class PhoneNumber
    {
        public string RawNumber { get; set; }
        public string SanitizedNumber { get; set; }
        public string Type { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public object DncStatus { get; set; }
        public object DncOtherInfo { get; set; }
        public bool PotentialHighRiskNumber { get; set; }
    }
}
