using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace BIG.Mobile.Views
{
   public partial  class DenunciaItemManager
    {
        static DenunciaItemManager defaultInstance = new DenunciaItemManager();
        MobileServiceClient client;

        IMobileServiceSyncTable<DenunciaItem> denunciaTable;
        const string offlineDbPath = @"localstore.db";
       
         

        private DenunciaItemManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);


            var store = new MobileServiceSQLiteStore(offlineDbPath);
            store.DefineTable<DenunciaItem>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.denunciaTable = client.GetSyncTable<DenunciaItem>();
        }

        public static DenunciaItemManager DefaultManager
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

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public bool IsOfflineEnabled
        {
            get { return denunciaTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<DenunciaItem>; }
        }


        


        
        public async Task<ObservableCollection<DenunciaItem>> GetTodoItemsAsync(bool syncItems = false)
        {
            try
            {

                if (syncItems)
                {
                    await this.SyncAsync();
                }

                IEnumerable<DenunciaItem> items = await denunciaTable
                    .Where(todoItem => !todoItem.Status)
                    .ToEnumerableAsync();

                return new ObservableCollection<DenunciaItem>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

      


        public async Task SaveTaskAsync(DenunciaItem item)
        {
            if (item.Id == null)
            {
                await denunciaTable.InsertAsync(item);
            }
            else
            {
                await denunciaTable.UpdateAsync(item);
            }
        }

        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.denunciaTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allTodoItems",
                    this.denunciaTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }

    }
}
