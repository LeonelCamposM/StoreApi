using Google.Api.Gax.ResourceNames;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

public class ProductRepository : IProductRepository
{
    private readonly FirestoreDb _firestoreDb;

    public ProductRepository(FirestoreDb firebaseClient)
    {
        _firestoreDb = firebaseClient;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(string category, string orderBy)
    {
        Console.WriteLine(category);
        Console.WriteLine(orderBy);
        //Query query = _firestoreDb.Collection("Products").OrderBy(orderBy).WhereEqualTo("Category", category);
        Query query = _firestoreDb.Collection("Products");
        QuerySnapshot snapshot = await query.GetSnapshotAsync();
        List<Product> products = new List<Product>();
        foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
        {
            Product product = documentSnapshot.ConvertTo<Product>();
            products.Add(product);
        }
        return products;
    }
}