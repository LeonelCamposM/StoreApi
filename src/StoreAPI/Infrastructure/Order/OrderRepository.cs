using Google.Api.Gax.ResourceNames;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

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

        // Check if the product already exists in the collection
        var query = userOrder.WhereEqualTo("Id", product.Id);
        var querySnapshot = await query.GetSnapshotAsync();

        if (querySnapshot.Documents.Count == 0)
        {
            // Product does not exist in the collection, add it
            await userOrder.AddAsync(product);
        }
        else
        {
            // Product already exists in the collection, do not add it again
            Console.WriteLine("Product already exists in the collection.");
        }
    }


    public Task CheckOut(string orderID)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string orderID, Order order)
    {
        throw new NotImplementedException();
    }
}