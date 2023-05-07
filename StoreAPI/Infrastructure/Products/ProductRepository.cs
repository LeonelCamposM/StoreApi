using Google.Api.Gax.ResourceNames;
using Google.Cloud.Firestore;

public class ProductRepository : IProductRepository
{
    private readonly FirestoreDb _firestoreDb;

    public ProductRepository(FirestoreDb firebaseClient)
    {
        _firestoreDb = firebaseClient;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        Query query = _firestoreDb.Collection("ProductsTest");
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