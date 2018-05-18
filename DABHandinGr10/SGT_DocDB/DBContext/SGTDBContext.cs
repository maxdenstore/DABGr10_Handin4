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
        public DocumentCollection SGT_Collection { get; set; }

        private SGT_DocDB.Repository.SGT_Repository _SGT_Repository;

        public DocumentClient client { get; set; }

        private const string _endPointUrl = "https://localhost:8081";
        private const string _PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string _Database = "SGT_DocDb";
        private const string _Collection = "SGTCollection";

        public SGTDBContext()
        {
            try
            {
                LoadDB().Wait();
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

        private async Task LoadDB()
        {
            client = new DocumentClient(new Uri(_endPointUrl), _PrimaryKey);
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = _Database });
            SGT_Collection = await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_Database)
                , new DocumentCollection { Id = _Database });
        }
    }
}
