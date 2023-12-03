using ForestWebApp.Models;

namespace ForestWebApp.Data;

/// <summary>
/// Interface for the Forest Repository.
/// Provides methods for interacting with Forest in the database
/// </summary>
public interface IForestRepository
{
    /// <summary>
    /// Retrieves a Forest asynchronously by its ID.
    /// </summary>
    /// <param name="id">The ID of the Forest object.</param>
    /// <returns>A Task that represents the asynchronous operation. The Task result contains the Forest object.</returns>
    public Task<Forest?> GetForestAsync(Guid id);

    /// <summary>
    /// Retrieves all Forest asynchronously.
    /// </summary>
    /// <returns>A Task that represents the asynchronous operation. The Task result contains an IEnumerable of Forest objects.</returns>
    public Task<IEnumerable<Forest>> GetForestsAsync();

    /// <summary>
    /// Adds a new Forest asynchronously.
    /// </summary>
    /// <param name="forest">The Forest to add.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public Task AddForestAsync(Forest forest);

    /// <summary>
    /// Updates an existing Forest asynchronously.
    /// </summary>
    /// <param name="forest">The Forest object to update.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public Task UpdateForestAsync(Forest forest);

    /// <summary>
    /// Deletes a Forest asynchronously.
    /// </summary>
    /// <param name="forest">The Forest object to delete.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public Task DeleteForestAsync(Forest forest);

    /// <summary>
    /// Retrieves a Forest asynchronously by its attributes.
    /// </summary>
    /// <param name="name">The name of the Forest.</param>
    /// <param name="country">The country of the Forest.</param>
    /// <param name="vegetation">The vegetation of the Forest.</param>
    /// <param name="area">The area of the Forest.</param>
    /// <param name="oldGrowthForest">Indicates whether the Forest is an old growth forest.</param>
    /// <returns>A Task that represents the asynchronous operation. The Task result contains the Forest object.</returns>
    public Task<Forest?> GetForestByAttributes(string name, string country, string vegetation, int area, bool oldGrowthForest);
}