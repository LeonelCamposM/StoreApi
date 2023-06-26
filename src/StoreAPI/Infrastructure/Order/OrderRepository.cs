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

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        Query query = _firestoreDb.Collection("Orders");

        QuerySnapshot snapshot = await query.GetSnapshotAsync();
        List<Order> orders = new List<Order>();

        foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
        {
            Order order = documentSnapshot.ConvertTo<Order>();
            orders.Add(order);
        }

        return orders;
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