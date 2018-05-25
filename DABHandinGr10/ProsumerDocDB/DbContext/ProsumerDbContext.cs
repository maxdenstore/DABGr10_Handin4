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

        private const string _endPointUrl = "https://f18i4dab.documents.azure.com:443/";
        private const string _PrimaryKey = "vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==";
        private const string _Database = "F18I4DABHGr10";
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
                //Console.WriteLine("End of Program");
            }
        }

        private async Task LoadDB()
        {
            client = new DocumentClient(new Uri(_endPointUrl), _PrimaryKey);
            client.CreateDatabaseIfNotExistsAsync(new Database { Id = _Database });
            ProsumorCollection = client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_Database), 
                new DocumentCollection { Id = _Database}).Result;


        }
    }
}
