using UnityEngine;
using Unprogressed.Common;

namespace Unprogressed.Inventory
{
    public class AddButtonHandler : MonoBehaviour
    {
        public void AddItem(Player.PlayerController playerController) => playerController._inventory.AddItem(ItemGenerator.GenerateItem(RandomAsset()));
        private ItemAsset RandomAsset() => ItemGenerator.ItemInfoList[(ItemType)Random.Range(1, ItemGenerator.ItemInfoList.Count)];
    }
}