using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BIG.Mobile.Views
{
   public partial class EmpleadoManager
    {

        static EmpleadoManager defaultInstance = new EmpleadoManager();
        MobileServiceClient client;

        IMobileServiceSyncTable<Empleados> empleadoTable;
        const string offlineDbPath = @"localstore.db";

        private EmpleadoManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
            var store = new MobileServiceSQLiteStore(offlineDbPath);
            store.DefineTable<Empleados>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.empleadoTable = client.GetSyncTable<Empleados>();
        }

        public static EmpleadoManager DefaultManager
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
            get { return empleadoTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<Empleados>; }
        }

        public async Task<ObservableCollection<Empleados>> GetTodoItemsAsync(bool syncItems = false)
        {
            try
            {

                if (syncItems)
                {
                    await this.SyncAsync();
                }

                IEnumerable<Empleados> items = await empleadoTable
                   .Where(todoItem => !todoItem.Bajalogica)
                   .ToEnumerableAsync();

                return new ObservableCollection<Empleados>(items);
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

        public async Task<List<Empleados>> GetListAsync2(bool syncItems = false)
        {
            if (syncItems)
            {
                await this.SyncAsync();
            }
            IEnumerable<Empleados> items = await empleadoTable
                .ToEnumerableAsync();
            return new List<Empleados>(items);
        }
        public async Task SaveTaskAsync(Empleados item)
        {
            if (item.Id == null)
            {
                await empleadoTable.InsertAsync(item);
            }
            else
            {
                await empleadoTable.UpdateAsync(item);
            }
        }


        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.empleadoTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allEmpleadosItems",
                    this.empleadoTable.CreateQuery());
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
