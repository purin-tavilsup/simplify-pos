using SimplifyPos.Domain.Entities.Catalog;

namespace SimplifyPos.Application.Abstractions;

public interface ICatalogProductRepository
{
    public Task<IEnumerable<CatalogProduct>> GetProductsByCategoryIdAsync(string categoryId);

    public Task<CatalogProduct> AddCatalogProduct(CatalogProduct entity);
}