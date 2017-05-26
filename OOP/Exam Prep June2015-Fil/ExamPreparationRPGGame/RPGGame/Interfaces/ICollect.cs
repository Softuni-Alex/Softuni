using RPGGame.Items;
using System.Collections.Generic;

namespace RPGGame.Interfaces
{
    public interface ICollect
    {

        IEnumerable<Item> Inventory { get; }

        void AddItemToInventory(Item item);

    }
}
