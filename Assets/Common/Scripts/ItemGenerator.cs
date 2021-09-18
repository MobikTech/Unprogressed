using System;
using System.Collections.Generic;
using UnityEngine;
using Unprogressed.Inventory;

namespace Unprogressed.Common
{
    public static class ItemGenerator
    {
        public static Dictionary<ItemType, ItemAsset> ItemInfoList { get; set; }


        //static ItemGenerator()
        //{
        //    InitializeItemList();
        //}

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeItemList()
        {
            //ItemInfoList = new Dictionary<int, ItemAsset>()
            //{
            //    { 0, Resources.Load<ItemAsset>("ItemTypes/" + (ItemType)0) },
            //    { 1, Resources.Load<ItemAsset>("ItemTypes/" + (ItemType)1) }
            //};
            string path = "ItemTypes/";
            ItemInfoList = new Dictionary<ItemType, ItemAsset>()
            {
                { ItemType.None, Resources.Load<ItemAsset>(path + "DefaultItem") },
                { ItemType.Axe, Resources.Load<ItemAsset>(path + ItemType.Axe.ToString()) },
                { ItemType.Sword, Resources.Load<ItemAsset>(path + ItemType.Sword.ToString()) }
            };
        }
        //public static GameObject Generate(int itemID, Vector3 spawnPoint)
        //{
        //    return GameObject.Instantiate<GameObject>(ItemInfoList[0].Prefab, spawnPoint, Quaternion.identity);
        //}

    }

}
