using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RPG_Engine.Services;

namespace RPG_Engine.Items
{
    internal class Inventory<T> where T : IItem
    {
        [JsonProperty]
        private readonly List<T> _items = new();

        public void AddItem(T item) => _items.Add(item);
        public void RemoveItem(T item) => _items.Remove(item);
        public IEnumerable<T> GetAllItems() => _items;

        public T GetItemByIndex(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException();

            return _items[index];
        }
    }
}
