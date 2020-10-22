using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
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

            var products = await _productRepository.GetAll(p => true);

            report.UpdateAt = DateTime.Now;
            report.AvgRate = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
              && p.SubCategory.Name == report.SubCategoryName).Select(x => x.AverageGrade).Average();
            report.AvgPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
               && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Average();
            report.MinPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
                && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Min();
            report.MaxPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
                && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Max();

            await _reportRepository.Create(report);
        }

        public async Task Delete(int? id)
        {
            var report = await _reportRepository.Get(id);

            if (report is null)
            {
                return;
            }

            await _reportRepository.Delete(id);
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

            var products = await _productRepository.GetAll(p => true);

            report.UpdateAt = DateTime.Now;
            report.AvgRate = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
              && p.SubCategory.Name == report.SubCategoryName).Select(x => x.AverageGrade).Average();
            report.AvgPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
               && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Average();
            report.MinPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
                && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Min();
            report.MaxPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
                && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Max();

            await _reportRepository.Update(report);
        }
    }
}
