using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace BIG.Mobile.Views
{
   public partial class ProductoManager
    {
        static ProductoManager defaultInstance = new ProductoManager();

        const string accountURL = @"https://gggc.documents.azure.com:443/";
        const string accountKey = @"n0pt0Jftn2mYbv4ziDGzwycOJCCgIKufJoJbjFRHqTX2ef2DmoMvn6CpRaSHHP7sOLM3DOe2ivAklb7IknChVA==";
        const string databaseId = @"ToDoList";
        const string collectionId = @"Products";
        //const string collectionId = @"Items";

        Uri collectionLink;
        

        DocumentClient client;


        private ProductoManager()
        {
            client = new DocumentClient(new System.Uri(accountURL), accountKey);
            collectionLink =  UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        }


        public static ProductoManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public List<Producto> Items { get; private set; }

        public async Task<List<Producto>> GetTodoItemsAsync()
        {
            try
            {
                // The query excludes completed TodoItems
                var query = client.CreateDocumentQuery<Producto>(collectionLink, new FeedOptions { MaxItemCount = -1 })
                      .Where(todoItem => todoItem.Visible == true)
                      .AsDocumentQuery();

                Items = new List<Producto>();
                while (query.HasMoreResults)
                {
                    Items.AddRange(await query.ExecuteNextAsync<Producto>());
                }


            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                return null;
            }

            return Items;
        }



    }
}
