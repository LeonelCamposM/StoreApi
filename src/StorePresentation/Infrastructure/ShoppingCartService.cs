using static StorePresentation.Pages.Index;

namespace StorePresentation.Infrastructure
{
    public class ShoppingCartItem
    {
        public Product SelectedProduct { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartItem(Product selectedProduct, int quantity)
        {
            SelectedProduct = selectedProduct;
            Quantity = quantity;
        }
    }

    public class ShoppingCartService
    {
        private List<ShoppingCartItem> _items = new List<ShoppingCartItem>();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = _items.FirstOrDefault(i => i.SelectedProduct.Name == product.Name);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new ShoppingCartItem(product, quantity));
            }
        }

        public void RemoveItem(Product product)
        {
            var itemToRemove = _items.FirstOrDefault(i => i.SelectedProduct.Name == product.Name);

            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }

        public List<ShoppingCartItem> GetItems()
        {
            return _items;
        }

        public double GetTotal()
        {
            return _items.Sum(i => i.SelectedProduct.Price * i.Quantity);
        }
    }
}
