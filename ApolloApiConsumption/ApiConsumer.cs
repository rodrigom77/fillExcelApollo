using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApolloApi.entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloApi
{


    public class ApiConsumer
    {
        private const string _peopleSearch = "https://app.apollo.io/api/v1/mixed_people/search";
        private const string _peopleEnrichment = "https://api.apollo.io/v1/people/match";
        private const string _organizationEnrichment = "https://api.apollo.io/v1/organizations/enrich";
        private const string _apiKey = "I2oe4_OLo5nwJyMYhflneA";

        private HttpClient client = new HttpClient();


        public async Task<SearchPeopleRootObject> SeachDataByFullName(string personName)
        {
            SearchPeopleRootObject responseBody = new SearchPeopleRootObject();
            var data = new { api_key = _apiKey, q_person_name = personName };

            string json = JsonConvert.SerializeObject(data);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync(_peopleSearch, content);
                response.EnsureSuccessStatusCode();

                var sresponseBody = await response.Content.ReadAsStringAsync();

                responseBody = JsonConvert.DeserializeObject<SearchPeopleRootObject>(sresponseBody);
            }

            return responseBody;

        }


        public async Task<PeopleEnrichmentRootObject> GetCompanyFieldsByEmployeeID(string empID)
        {
            PeopleEnrichmentRootObject responseBody = new PeopleEnrichmentRootObject();
            var data = new { api_key = _apiKey, id = empID };

            // Convert the object to JSON
            string json = JsonConvert.SerializeObject(data);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync(_peopleEnrichment, content);
                response.EnsureSuccessStatusCode();

                var sresponseBody = await response.Content.ReadAsStringAsync();

                responseBody = JsonConvert.DeserializeObject<PeopleEnrichmentRootObject>(sresponseBody);
            }

            return responseBody;

        }

        public async Task<OrganizationRootObject> GetCompanyByEmailDomain(string domain)
        {

            if (domain == null || domain.Equals("yahoo.com") ||  domain.Equals("aol.com"))
            {
                return null;
            }

            OrganizationRootObject responseBody = new OrganizationRootObject();
            
            HttpResponseMessage response = await client.GetAsync($"{_organizationEnrichment}?api_key={_apiKey}&domain={domain}");
            response.EnsureSuccessStatusCode();

            // Read and return the response body
            var sresponseBody = await response.Content.ReadAsStringAsync();

            responseBody = JsonConvert.DeserializeObject<OrganizationRootObject>(sresponseBody);

            return responseBody;
        }

        public async Task<responseDto> GetCompaniesByName(string name)
        {
            var empty = string.Empty;

            try
            {
                var key = "I2oe4_OLo5nwJyMYhflneA";
                var result = new responseDto();
                result.revenue = empty;
                result.industry = empty;
                result.numEmp = empty;
                bool domainFound = false;

                var values = new Dictionary<string, string>
                {
                      { "api_key", key },
                      { "q_organization_name", name }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://api.apollo.io/api/v1/mixed_companies/search", content);

                var responseString = await response.Content.ReadAsStringAsync();

                dynamic dynamicResult = JToken.Parse(responseString);

                var organizations = dynamicResult.organizations;

                var accounts = dynamicResult.accounts;

                foreach (var organization in organizations)
                {
                    if (organization.name.ToString().ToLower().Trim() == name.ToLower().Trim() && !domainFound)
                    {
                        domainFound = true;

                        var domain = organization.primary_domain;

                        var requestGet = $"https://api.apollo.io/v1/organizations/enrich?api_key={key}&domain={domain}";

                        var getresponse = await client.GetAsync(requestGet);

                        var _responseString = await getresponse.Content.ReadAsStringAsync();

                        dynamic _dynamicResult = JToken.Parse(_responseString);

                        var numeployess = "";

                        try
                        {
                            numeployess = _dynamicResult.organization.estimated_num_employees?.ToString() ?? "";
                        }
                        catch (Exception)
                        {

                        }

                        var revenue = "";

                        try
                        {
                            revenue = _dynamicResult.organization.annual_revenue?.ToString() ?? "";
                        }
                        catch (Exception)
                        {

                        }

                        var industry = "";

                        try
                        {
                            industry = dynamicResult.organization.industry?.ToString() ?? "";
                        }
                        catch (Exception)
                        {
                        }

                        result.numEmp = numeployess;
                        result.revenue = revenue;
                        result.industry = industry;

                    }
                }

                //Console.WriteLine("");

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var responseext = new responseDto();
                responseext.revenue = empty;
                responseext.industry = empty;
                responseext.numEmp = empty;
                return responseext;
            }
        }




    }



}
