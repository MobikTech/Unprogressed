using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unprogressed.Inventory
{
    [CreateAssetMenu(menuName = "ItemType", fileName = "DefaultType")]
    public class ItemAsset : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Dictionary<string, int> _stats = new Dictionary<string, int>();
        [SerializeField] private ItemType _type;
        //[SerializeField] private GameObject _prefab;

        public string Ttitle => _title;
        public string Description => _description; 
        public Sprite Icon => _icon;
        public Dictionary<string, int> Stats => _stats;
        public ItemType ItemType => _type;

        //public ItemType Type => _type;
        //public GameObject Prefab => _prefab;
    }
}
