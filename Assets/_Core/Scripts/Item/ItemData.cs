using UnityEngine;

namespace AmazingShop.Item
{
    [CreateAssetMenu(fileName = "new_" + nameof(ItemData), menuName = "ScriptableObject/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _purchasePrice; // Prix d'Achat
        [SerializeField] private int _sellingPrice; // Prix de Vente
        [SerializeField] private string _description;
        [SerializeField] private int _currentQuantity;
        [SerializeField] private int _quantityMax;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public int PurchasePrice => _purchasePrice;
        public int SellingPrice => _sellingPrice;
        public string Description => _description;
        public int CurrentQuantity
        {
            get => _currentQuantity;
            set => _currentQuantity = Mathf.Clamp(value, 0, _quantityMax);
        }
        public int QuantityMax => _quantityMax;
    }
}