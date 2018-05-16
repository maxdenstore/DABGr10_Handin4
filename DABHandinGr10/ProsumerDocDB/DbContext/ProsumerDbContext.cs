using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ProsumerDocDB.DbContext
{
    public class ProsumerDbContext
    {
        public DocumentCollection ProsumorCollection { get; set; }

        private ProsumerDocDB.Repository.ProsumerRepository _prosumorsRepository;

        public DocumentClient client { get; set; }

        private const string _endPointUrl = "https://localhost:8081";
        private const string _PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string _Database = "ProsumorDocDb";
        private const string _Collection = "ProsumorCollection";

        public ProsumerDbContext()
        {
            try
            {
                LoadDB().Wait();
            }
            catch (Exception e)
            {
                Exception exception = e.GetBaseException();
            }
            finally
            {
                Console.WriteLine("End of Program");
            }
        }

        private async Task LoadDB()
        {
            client = new DocumentClient(new Uri(_endPointUrl), _PrimaryKey);
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = _Database });
            ProsumorCollection = await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_Database), 
                new DocumentCollection { Id = _Database});

        }
    }
}
