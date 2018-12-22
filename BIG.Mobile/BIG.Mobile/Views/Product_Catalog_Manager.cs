using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

using System.Threading.Tasks;
using System.Linq;

namespace BIG.Mobile.Views
{
    public class Product_Catalog_Manager
    {
        static Product_Catalog_Manager defaultInstance = new Product_Catalog_Manager();

        const string accountURL = @"https://gggc.documents.azure.com:443/";
        const string accountKey = @"n0pt0Jftn2mYbv4ziDGzwycOJCCgIKufJoJbjFRHqTX2ef2DmoMvn6CpRaSHHP7sOLM3DOe2ivAklb7IknChVA==";
        const string databaseId = @"ToDoList";
        const string collectionId = @"Product_Catalog";
        //const string collectionId = @"Items";

        Uri collectionLink;


        DocumentClient client;


        private Product_Catalog_Manager()
        {
            client = new DocumentClient(new System.Uri(accountURL), accountKey);
            collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        }
        public static Product_Catalog_Manager DefaultManager
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

        public List<Product_Catalog> Items { get; private set; }

        public async Task<List<Product_Catalog>> GetTodoItemsAsync()
        {
            try
            {
                // The query excludes completed TodoItems
                var query = client.CreateDocumentQuery<Producto>(collectionLink, new FeedOptions { MaxItemCount = -1 })
                      .Where(todoItem => todoItem.Visible == true)
                      .AsDocumentQuery();

                Items = new List<Product_Catalog>();
                while (query.HasMoreResults)
                {
                    Items.AddRange(await query.ExecuteNextAsync<Product_Catalog>());
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
