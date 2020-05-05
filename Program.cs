using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureASATables
{
    class Program
    {
        static void Main()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=mysgstorage;AccountKey=+jGZPwhioMYOBxx3lHjrsF7T16J+8Dw2LqReb2UPutSO4IY/Uofh13yeAmUA70b3RoKnGReN7AxfV8T8ON70Zw==;EndpointSuffix=core.windows.net");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable employees = tableClient.GetTableReference("Employee");

            employees.CreateIfNotExistsAsync();

            EmployeeEntity employees1 = new EmployeeEntity("tanish", "guleria");


            TableOperation inserttop = TableOperation.Insert(employees1);
            employees.ExecuteAsync(inserttop).GetAwaiter().GetResult();
        }
    }

    public class EmployeeEntity : TableEntity
    {
        public EmployeeEntity( string firstname , string lastname )
        {
            this.PartitionKey = "staff";
            this.RowKey = firstname + " " + lastname;
          

        }
    }
}
