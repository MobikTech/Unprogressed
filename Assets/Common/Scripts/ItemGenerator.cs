using System;
using System.Collections.Generic;
using UnityEngine;
using Unprogressed.Inventory;

namespace Unprogressed.Common
{
    public static class ItemGenerator
    {
        public static Dictionary<int, ItemAsset> ItemInfoList { get; set; }

        //static ItemGenerator()
        //{
        //    InitializeItemList();
        //}

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeItemList()
        {
            ItemInfoList = new Dictionary<int, ItemAsset>()
            {
                { 0, Resources.Load<ItemAsset>("ItemTypes/" + (ItemType)0) },
                { 1, Resources.Load<ItemAsset>("ItemTypes/" + (ItemType)1) }
            };
        }
        public static GameObject Generate(int itemID, Vector3 spawnPoint)
        {
            return GameObject.Instantiate<GameObject>(ItemInfoList[0].Prefab, spawnPoint, Quaternion.identity);
        }

    }

}
