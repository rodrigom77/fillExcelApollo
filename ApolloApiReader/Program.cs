using System;
using System.IO;
using System.Linq;
using ApolloApi;
using Bytescout.Spreadsheet;

namespace ApolloApiReader
{
    internal class Program
    {
        private static string notAllowed = "gmail.com, yahoo.com, aol.com, outlook.com";
        private static string filePath = @"C:\Users\rodri\OneDrive\Escritorio\allevents1.xlsx";


        static void Main(string[] args)
        {

            try
            {

                Spreadsheet document = new Spreadsheet();
                document.LoadFromFile(filePath);

                //var workBook = WorkBook.Load(filePath);
                //var workSheet = workBook.WorkSheets.First();

                Worksheet workSheet = document.Workbook.Worksheets.ByName("nocompanies");

                var _apiConsumer = new ApolloAPIInvoke();

                // Find the "Email" column index
                var headerRow = workSheet.Rows[0]; // Assuming the first row is the header
                int emailColumnIndex = -1;
                for (int col = 0; col < headerRow.ColumnMax; col++)
                {
                    if (headerRow[col].Value.Equals("Email"))
                    {
                        emailColumnIndex = col;
                        break;
                    }
                }

                //// Check if the "Email" column was found
                if (emailColumnIndex == -1)
                {
                    Console.WriteLine("Email column not found.");
                    return;
                }

                var firstRow = 246;
                var lastRow = 650;

                //// Iterate through the rows, starting from the row after the header
                for (int row = firstRow; row <lastRow; row++)
                {

                    try
                    {
                        Console.WriteLine($"Row: {row} of {lastRow}");

                        var emailCell = workSheet.Cell(row, emailColumnIndex);
                        var companyCell = workSheet.Cell(row, 7);


                        // To avoid unnecesary invokes if the value was already processed
                        var Revenuecell = workSheet.Cell(row, 9);
                        if (Revenuecell != null && !string.IsNullOrEmpty(Revenuecell.Value?.ToString())) continue;

                        // By Company name #1
                        var companyToCheck = companyCell.Value?.ToString();

                        Console.WriteLine($"Company: {companyToCheck}");

                        if (!string.IsNullOrEmpty(companyToCheck))
                        {
                            var CompanyByNameDTO = _apiConsumer.GetCompaniesByName(companyToCheck).Result;

                            if (CompanyByNameDTO != null)
                            {
                                Console.WriteLine($" Revenue: {CompanyByNameDTO.revenue}:: Employees: {CompanyByNameDTO.numEmp}::Industy: {CompanyByNameDTO.industry}");

                                var Employeecell = workSheet.Cell(row, 10);
                                var Industrycell = workSheet.Cell(row, 11);

                                Revenuecell.Value = CompanyByNameDTO.revenue;
                                Employeecell.Value = CompanyByNameDTO.numEmp;
                                Industrycell.Value = CompanyByNameDTO.industry;

                                if (string.IsNullOrEmpty(CompanyByNameDTO.revenue) &&
                                    string.IsNullOrEmpty(CompanyByNameDTO.numEmp) &&
                                    string.IsNullOrEmpty(CompanyByNameDTO.industry))
                                {
                                    Console.WriteLine("Company {0} No Data found. Lookig for Email Domain {1}", companyToCheck, emailCell);
                                    UpdateExcelByEmailDomainName(emailCell, workSheet, row);
                                }

                            }
                            else
                            {
                                // #2 

                                Console.WriteLine("Company {0} not found. Lookig for Email Domain {1}", companyToCheck, emailCell);
                                UpdateExcelByEmailDomainName(emailCell, workSheet, row);
                            }
                        }
                        else
                        {
                            // #2 
                            Console.WriteLine("Company cell empty. Lookig for Email Domain {0}", emailCell);
                            UpdateExcelByEmailDomainName(emailCell, workSheet, row);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.ToString());
                    }
                }

                document.SaveAs(filePath);

                Console.WriteLine("EXCEL SAVED");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("F I N I S H");

            Console.ReadLine();
        }


        private static void UpdateExcelByEmailDomainName(Cell Currentcell, Worksheet workSheet, int row)
        {


            if (Currentcell != null && !string.IsNullOrEmpty(Currentcell.Value?.ToString()))
            {

                var Revenuecell = workSheet.Cell(row, 9);

                // if Revenuecell is not null and not empty, row was already processed
                if (Revenuecell != null && !string.IsNullOrEmpty(Revenuecell.Value?.ToString())) return;

                ApolloAPIInvoke apiConsumer = new ApolloAPIInvoke();

                string[] notAllowedArray = notAllowed.Split(',');
                bool found = false;
                foreach (string ommitEmail in notAllowedArray)
                {
                    if (Currentcell.Value.ToString().Split('@')[1].Equals(ommitEmail))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine(Currentcell.Value.ToString());
                    var MarkXEmailDomaincell = workSheet.Cell(row, 13);
                    var domain = Currentcell.Value?.ToString().Split('@')[1];
                    var organizationRootObject = apiConsumer.GetCompanyByEmailDomain(domain).Result;

                    if (organizationRootObject == null)
                    {
                        return;
                    }

                    if (organizationRootObject.Organization == null)
                    {
                        Console.WriteLine("No Organization found");
                        MarkXEmailDomaincell.Value = "No Organization found";
                        return;
                    }

                    Console.WriteLine($" Revenue: {organizationRootObject.Organization.AnnualRevenue}:: Employees: {organizationRootObject.Organization.EstimatedNumEmployees}::Industy: {organizationRootObject.Organization.Industry}");

                    var Employeecell = workSheet.Cell(row, 10);
                    var Industrycell = workSheet.Cell(row, 11);

                    Revenuecell.Value = organizationRootObject.Organization.AnnualRevenue;
                    Employeecell.Value = organizationRootObject.Organization.EstimatedNumEmployees;
                    Industrycell.Value = organizationRootObject.Organization.Industry;

                    MarkXEmailDomaincell.Value = "Found";
                }
            }
        }
    }
}