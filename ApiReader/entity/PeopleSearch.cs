using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloApi.entity
{
    public class SearchPeopleRootObject
    {
        public List<Breadcrumb> Breadcrumbs { get; set; }
        public bool PartialResultsOnly { get; set; }
        public bool DisableEuProspecting { get; set; }
        public int PartialResultsLimit { get; set; }
        public Pagination Pagination { get; set; }
        public List<object> Contacts { get; set; }
        public List<Person> People { get; set; }
        public List<string> ModelIds { get; set; }
        public object NumFetchResult { get; set; }
        public DerivedParams DerivedParams { get; set; }
    }

    public class Breadcrumb
    {
        public string Label { get; set; }
        public string SignalFieldName { get; set; }
        public string Value { get; set; }
        public string DisplayName { get; set; }
    }

    public class Pagination
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalEntries { get; set; }
        public int TotalPages { get; set; }
    }

    public class Person
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
        public object ExtrapolatedEmailConfidence { get; set; }
        public string Headline { get; set; }
        public object Email { get; set; }
        public string OrganizationId { get; set; }
        public List<EmploymentHistory> EmploymentHistory { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<string> Departments { get; set; }
        public List<string> Subdepartments { get; set; }
        public string Seniority { get; set; }
        public List<string> Functions { get; set; }
        public object IntentStrength { get; set; }
        public bool ShowIntent { get; set; }
        public bool RevealedForCurrentTeam { get; set; }
    }

    public class EmploymentHistory
    {
        public string Id { get; set; }
        public object CreatedAt { get; set; }
        public bool Current { get; set; }
        public object Degree { get; set; }
        public object Description { get; set; }
        public object Emails { get; set; }
        public object EndDate { get; set; }
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

    public class DerivedParams
    {
    }
}
