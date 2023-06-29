using Google.Api.Gax.ResourceNames;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Domain.Order;

public class OrderRepository : IOrderRepository
{
    private readonly FirestoreDb _firestoreDb;

    public OrderRepository(FirestoreDb firebaseClient)
    {
        _firestoreDb = firebaseClient;
    }

    public async Task AddToOrderAsync(Product product, string orderID)
    {
        var userOrder = _firestoreDb.Collection("Orders").Document(orderID).Collection("items");
        var query = userOrder.WhereEqualTo("Id", product.Id);
        var querySnapshot = await query.GetSnapshotAsync();

        if (querySnapshot.Documents.Count == 0) {
            OrderItem item = new OrderItem
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1,
                Image = product.Image
            };
            await userOrder.AddAsync(item);
        }
    }

    public async Task CheckOut(Order order, string orderID)
    {
        var userOrder = _firestoreDb.Collection("ProcessedOrders").Document();
        await userOrder.SetAsync(order);
        List<OrderItem> orderItems = await GetByIdAsync(orderID);
        var orderItemsCollection = _firestoreDb.Collection("Orders").Document(orderID).Collection("items");
        foreach (OrderItem item in orderItems)
        {
            await userOrder.Collection("items").AddAsync(item);
        }

        QuerySnapshot existingItemsSnapshot = await orderItemsCollection.GetSnapshotAsync();
        foreach (DocumentSnapshot documentSnapshot in existingItemsSnapshot.Documents)
        {
            await documentSnapshot.Reference.DeleteAsync();
        }

    }

    public async Task<List<OrderWithItems>> GetAllAsync()
    {
        var processedOrders = _firestoreDb.Collection("ProcessedOrders");
        QuerySnapshot snapshot = await processedOrders.GetSnapshotAsync();
        List<OrderWithItems> orders = new List<OrderWithItems>();
        foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
        {
            Query query = _firestoreDb.Collection("ProcessedOrders").Document(documentSnapshot.Id).Collection("items");
            QuerySnapshot snapshot2 = await query.GetSnapshotAsync();
            List<OrderItem> products = snapshot2.Documents.Select(document => document.ConvertTo<OrderItem>()).ToList();
            Order order = documentSnapshot.ConvertTo<Order>();
            OrderWithItems orderWithItems = new OrderWithItems(order, products);
            orders.Add(orderWithItems);
        }

        return orders;
    }

    public async Task<List<OrderItem>> GetByIdAsync(string orderID)
    {
        Query query = _firestoreDb.Collection("Orders").Document(orderID).Collection("items");
        QuerySnapshot snapshot = await query.GetSnapshotAsync();
        List<OrderItem> products = snapshot.Documents.Select(document => document.ConvertTo<OrderItem>()).ToList();
        return products;
    }

    public async Task UpdateAsync(string orderID, List<OrderItem> order)
    {
        var userOrder = _firestoreDb.Collection("Orders").Document(orderID).Collection("items");

        // Delete existing order items
        QuerySnapshot existingItemsSnapshot = await userOrder.GetSnapshotAsync();
        foreach (DocumentSnapshot documentSnapshot in existingItemsSnapshot.Documents)
        {
            await documentSnapshot.Reference.DeleteAsync();
        }

        // Add updated order items
        foreach (OrderItem item in order)
        {
            await userOrder.AddAsync(item);
        }
    }
}