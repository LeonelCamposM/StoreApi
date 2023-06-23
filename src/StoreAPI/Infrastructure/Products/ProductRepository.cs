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

    public Task AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
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

    public async Task<Product> GetByidAsync(string id)
    {
        Console.WriteLine(id);
        Query query = _firestoreDb.Collection("Products").WhereEqualTo("Id", id);
        QuerySnapshot snapshot = await query.GetSnapshotAsync();
        if (snapshot.Documents.Count == 0)
        {
            // Product with the given ID was not found
            return null; 
        }
        DocumentSnapshot documentSnapshot = snapshot.Documents[0];
        Product product = documentSnapshot.ConvertTo<Product>();
        return product;
    }

    public async Task UpdateAsync(string id, Product product)
    {
        // First, check if the product exists using GetByidAsync
        Product existingProduct = await GetByidAsync(id);

        if (existingProduct == null)
        {
            // Product with the given ID was not found
            throw new Exception("Product not found.");
        }

        // Update the product properties
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;

        // Update the product in the Firestore database
        DocumentReference documentRef = _firestoreDb.Collection("Products").Document(id);
        await documentRef.SetAsync(existingProduct);
    }
}