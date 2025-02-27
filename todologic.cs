using System.Collections.Generic;

namespace ToDoLogic
{
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class ToDoList
    {
        private ToDoList<string> items = new ToDoList<string>();

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        public ToDoList<string> GetItems()
        {
            return items;
        }
    }

    public class CosmosDbHelper
    {
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;
        
        public CosmosDbHelper(string connectionString, string databaseName, string containerName)
        {
            cosmosClient = new CosmosClient(connectionString);
            database = cosmosClient.GetDatabase(databaseName);
            container = database.GetContainer(containerName);
        }

        public async Task<List<ToDoItem>> GetToDoItemsByUserAsync(string userId)
        {           
            var sqlQueryText = $"SELECT * FROM c WHERE c.userId = '{userId}'";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<ToDoItem> queryResultSetIterator = container.GetItemQueryIterator<ToDoItem>(queryDefinition);

            List<ToDoItem> items = new List<ToDoItem>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<ToDoItem> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (ToDoItem item in currentResultSet)
                {
                    items.Add(item);
                }
            }

            return items;
        }
}