using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IProductRepository _productRepository;

        public ReportService(IReportRepository reportRepository, IProductRepository productRepository)
        {
            _reportRepository = reportRepository;
            _productRepository = productRepository;
        }

        public async Task Create(Report report)
        {

            if (report is null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            report.UpdateAt = DateTime.Now;

            report.AvgRate = await _productRepository.GetAvgGrade(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            report.AvgPrice = await _productRepository.GetAvgPrice(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            report.MinPrice = await _productRepository.GetMinPrice(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            report.MaxPrice = await _productRepository.GetMaxPrice(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            await _reportRepository.Create(report);
        }

        public async Task GenerateReports()
        {
            var reports = await _reportRepository.GetAll(r => true);
            foreach (var report in reports)
            {
                await _reportRepository.Delete(report);
            }

            var products = await _productRepository.GetAll(p => true);

            var uniqueProducts = products.Select(x => new { ProductName = x.Name, x.CategoryId}).Distinct();

            foreach (var product in uniqueProducts)
            {
                await Create(new Report() { ProductName = product.ProductName, CategoryId = product.CategoryId});
            }

        }

        public async Task Delete(int? id)
        {
            var report = await _reportRepository.Get(id);

            if (report is null)
            {
                return;
            }

            await _reportRepository.Delete(report);
        }

        public async Task<Report> Get(int? id)
        {
            var report = await _reportRepository.Get(id);

            if (report is null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            return report;
        }

        public async Task<IList<Report>> GetAll(Expression<Func<Report, bool>> filter = null)
        {
            if (filter is null)
            {
                return await _reportRepository.GetAll(r => true);
            }

            return await _reportRepository.GetAll(filter);
        }

        public async Task<IList<Report>> GetPaginated(Expression<Func<Report, bool>> filter = null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return await _reportRepository.GetPaginated(p => true, pageSize, productPage);
            }

            return await _reportRepository.GetPaginated(filter, pageSize, productPage);
        }

        public async Task<bool> Exist(Expression<Func<Report, bool>> filter)
        {
            var reportEntity = await _reportRepository.Get(filter);
            if (reportEntity is null)
            {
                return false;
            }
            return true;
        }

        public async Task Update(Report report)
        {
            if (report is null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            report.UpdateAt = DateTime.Now;

            report.AvgRate = await _productRepository.GetAvgGrade(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            report.AvgPrice = await _productRepository.GetAvgPrice(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            report.MinPrice = await _productRepository.GetMinPrice(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            report.MaxPrice = await _productRepository.GetMaxPrice(p => p.Name.ToLower() == report.ProductName.ToLower() && p.Category.Id == report.CategoryId);

            await _reportRepository.Update(report);
        }

        public async Task<(IList<Report> reports, int reportsCount)> GetFiltered(string productName = null, string categoryName = null, int? pageSize = null, int? productPage = null)
        {
            var reports = await GetAll();

            if (productName is null && categoryName is null)
            {
                return (await GetPaginated(s => true, pageSize.Value, productPage.Value), reports.Count);
            }
            else if (!(productName is null || categoryName is null))
            {
                reports = await GetAll(r => r.ProductName.ToLower()
                                     .Contains(productName.ToLower()) && r.Category.Name.ToLower()
                                     .Contains(categoryName.ToLower()));

                return (await GetPaginated(r => r.ProductName.ToLower()
                                    .Contains(productName.ToLower()) && r.Category.Name.ToLower()
                                    .Contains(categoryName.ToLower()), pageSize.Value, productPage.Value), reports.Count);
            }
            else if (!(productName is null))
            {
                reports = await GetAll(r => r.ProductName.ToLower().Contains(productName.ToLower()));

                return (await GetPaginated(r => r.ProductName.ToLower().Contains(productName.ToLower()), pageSize.Value, productPage.Value), reports.Count);
            }
            else if (!(categoryName is null))
            {
                reports = await GetAll(r => r.Category.Name.ToLower().Contains(categoryName.ToLower()));

                return (await GetPaginated(r => r.Category.Name.ToLower().Contains(categoryName.ToLower()), pageSize.Value, productPage.Value), reports.Count);
            }

            return (reports, reports.Count);
        }
    }
}
