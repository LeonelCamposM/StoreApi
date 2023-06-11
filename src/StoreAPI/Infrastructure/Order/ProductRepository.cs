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