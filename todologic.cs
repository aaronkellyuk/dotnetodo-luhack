using System.Collections.Generic;

namespace ToDoLogic
{
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
}