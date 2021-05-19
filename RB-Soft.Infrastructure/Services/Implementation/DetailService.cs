using RB_Soft.Data.Core;
using RB_Soft.Data.Entities;
using RB_Soft.Data.Entities.Logging;
using RB_Soft.Infrastructure.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RB_Soft.Infrastructure.Services.Implementation
{
    public class DetailService : IDetailService
    {
        private readonly IGenericRepository<Detail> details;
        private readonly IGenericRepository<Category> categories;
        private readonly IGenericRepository<Brand> brands;
        private readonly IGenericRepository<Country> countries;

        private readonly IDatabaseTransaction transaction;

        private readonly IGenericRepository<Log> logs;

        public DetailService(
            IGenericRepository<Detail> details, 
            IGenericRepository<Category> categories,
            IGenericRepository<Brand> brands,
            IGenericRepository<Country> countries,
            IDatabaseTransaction transaction,
            IGenericRepository<Log> logs)
        {
            this.details = details;
            this.categories = categories;
            this.brands = brands;
            this.countries = countries;
            this.transaction = transaction;
            this.logs = logs;
        }

        public async Task<Detail> CreateAsync(DetailModel detail)
        {
            transaction.Begin();

            var newDetail = await BuildDetailModelAsync(detail);

            if (await details.CreateAsync(newDetail) == null)
            {
                transaction.Rollback();

                await logs.CreateAsync(new Log($"Entity {nameof(Detail)} wasn`t created.", LogLevel.Fatal));

                return null;
            }

            transaction.Commit();

            await logs.CreateAsync(new Log($"Entity {nameof(Detail)} was succesfully created.", LogLevel.Info));

            return newDetail;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await details.RemoveAsync(id);
        }

        public async Task<IEnumerable<Detail>> GetAsync(int page, int count)
        {
            if (page < 1)
                page = 1;

            return (await details.GetWithIncludeAsync(d => d.Brand, d => d.Category, d => d.Country)).Skip((page-1) * count).Take(count);
        }

        public async Task<Detail> GetByIdAsync(int id)
        {
            return (await details.GetWithIncludeAsync(d => d.BrandId.Equals(id), d => d.Brand, d => d.Category, d => d.Country)).FirstOrDefault();
        }

        public async Task<Detail> UpdateAsync(DetailModel detail)
        {
            transaction.Begin();

            var newDetail = await BuildDetailModelAsync(detail);

            if (await details.UpdateAsync(newDetail) == null)
            {
                transaction.Rollback();
                return null;
            }

            transaction.Commit();
            return newDetail;
        }

        private async Task<Detail> BuildDetailModelAsync(DetailModel detail)
        {
            var country = await countries.FindAsync(detail.Country);
            if (country == null)
                country = await countries.CreateAsync(new Country() { Name = detail.Country });

            var brand = (await brands.GetAsync(b => b.Name.Equals(detail.Brand))).FirstOrDefault();
            if (brand == null)
                brand = await brands.CreateAsync(new Brand() { Name = detail.Brand });

            var category = (await categories.GetAsync(b => b.Name.Equals(detail.Category))).FirstOrDefault();
            if (category == null)
                category = await categories.CreateAsync(new Category() { Name = detail.Category });

            var newDetail = new Detail
            {
                Brand = brand,
                BrandId = brand.BrandId,
                Country = country,
                CountryName = country.Name,
                Category = category,
                CategoryId = category.CategoryId,

                DetailId = detail.DetailId,
                Name = detail.Name,
                Color = detail.Color,
                Material = detail.Material
            };

            return newDetail;
        }
    }
}
