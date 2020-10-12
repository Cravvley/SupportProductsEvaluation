using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IProductRepository _productRepository;
        public ReportService(IReportRepository reportRepository, IProductRepository productRepository)
        {
            _reportRepository= reportRepository;
            _productRepository = productRepository;
        }
        public async Task Create(Report report)
        {

            if (report == null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            var products = await _productRepository.GetAll();

            report.UpdateAt = DateTime.Now;
            report.AvgRate = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
              && p.SubCategory.Name == report.SubCategoryName).Select(x => x.AverageGrade).Average();
            report.AvgPrice= products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
              && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Average();

            await _reportRepository.Create(report);
        }

        public async Task Delete(int? id)
        {
            var report = await _reportRepository.Get(id);

            if (report == null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            await _reportRepository.Delete(id);
        }

        public async Task<Report> Get(int? id)
        {
            var report = await _reportRepository.Get(id);

            if (report == null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            return report;
        }

        public async Task<IList<Report>> GetAll()
               => await _reportRepository.GetAll();

        public async Task<bool> IsExist(Report report)
        {
            var reportEntity = await _reportRepository.Get(report);
            if (reportEntity == null)
            {
                return false;
            }
            return true;
        }

        public async Task Update(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException("report doesn't exist");
            }

            var products = await _productRepository.GetAll();

            report.UpdateAt = DateTime.Now;
            report.AvgRate = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
              && p.SubCategory.Name == report.SubCategoryName).Select(x => x.AverageGrade).Average();
            report.AvgPrice = products.Where(p => p.Name == report.ProductName && p.Category.Name == report.CategoryName
               && p.SubCategory.Name == report.SubCategoryName).Select(x => x.Price).Average();

            await _reportRepository.Update(report);
        }
    }
}
