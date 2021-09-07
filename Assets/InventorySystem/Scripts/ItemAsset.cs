using System;
using UnityEngine;

namespace Unprogressed.Inventory
{
    [CreateAssetMenu(menuName = "ItemType", fileName = "DefaultType")]
    public class ItemAsset : ScriptableObject
    {
        [SerializeField] private Int32 _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemType _type;
        [SerializeField] private GameObject _prefab;

        public Int32 ID => _id;
        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
        public ItemType Type => _type;
        public GameObject Prefab => _prefab;

    }
}
