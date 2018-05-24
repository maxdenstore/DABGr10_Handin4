using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace SGT_DocDB.DBContext
{
    public class SGTDBContext
    {
        public DocumentCollection temp { get; set;}

        //public DocumentCollection upcommingTransactions { get; set; }
        //public DocumentCollection previousTransactions { get; set; }
        //public DocumentCollection onGoingTransactions { get; set; }

        private SGT_DocDB.Repository.SGT_Repository _SGT_Repository;

        public DocumentClient client { get; set; }

        //private const string _endPointUrl = "https://f18i4dab.documents.azure.com:443/";
        //private const string _PrimaryKey = "vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==";

        private const string _endPointUrl = "https://localhost:8081/";
        private const string _PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string _Database = "F18I4DABH4Gr10";
        private string _Collection;
        private const string _upcomingCollection = "upcomingTransactionsCollection";
        private const string _previousCollection = "previousTransactionsCollection";
        private const string _onGoingCollection = "onGoingTransactionsCollection";

        public SGTDBContext(string transaction)
        { 
            try
            {
                LoadDB(transaction).Wait();
            }
            catch(Exception e)
            {
                Exception exception = e.GetBaseException();
            }
            finally
            {
                Console.WriteLine("End of program, SGT");
            }
        }

        private async Task LoadDB(string transaction)
        {

            if (transaction == "upcomming")
            {
                _Collection = _upcomingCollection;
            }
            else if (transaction == "onGoing")
            {
                _Collection = _onGoingCollection;
            }
            else if(transaction == "previous")
            {
                _Collection = _previousCollection;
            }
            else
            {
                Console.WriteLine("Invaild Collection");
                return;
            }

            client = new DocumentClient(new Uri(_endPointUrl), _PrimaryKey);
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = _Database });
            temp = await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_Database)
                , new DocumentCollection { Id = _Collection });
        }
    }
}
