using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Data;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _db;

        public ReportRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Create(Report report)
        {
            _db.Report.Add(report);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var reportEntity = await  Get(id);
            _db.Report.Remove(reportEntity);
            await _db.SaveChangesAsync();
        }

        public async Task<Report> Get(int? id)
                =>await _db.Report.SingleOrDefaultAsync(r => r.Id == id);

        public async Task<Report> Get(Expression<Func<Report, bool>> filter)
                => await _db.Report.FirstOrDefaultAsync(filter);

        public async Task<IList<Report>> GetAll(Expression<Func<Report, bool>> filter)
                => await _db.Report.Where(filter).AsQueryable().ToListAsync();

        public async Task<IList<Report>> GetPaginated(Expression<Func<Report, bool>> filter, int pageSize = 1, int productPage = 1)
            => await _db.Report.AsNoTracking().Where(filter).AsQueryable().OrderBy(p => p.ProductName)
                                        .Skip((productPage - 1) * pageSize)
                                        .Take(pageSize).ToListAsync();

        public async Task Update(Report report)
        {
            _db.Update(report);
            //var reportEntity = await Get(report.Id);
            //reportEntity.MinPrice = report.MinPrice;
            //reportEntity.MaxPrice = report.MaxPrice;
            //reportEntity.AvgPrice = report.AvgPrice;
            //reportEntity.AvgRate = report.AvgRate;
            //reportEntity.CategoryName = report.CategoryName;
            //reportEntity.ProductName = report.ProductName;
            //reportEntity.SubCategoryName = report.SubCategoryName;
            //reportEntity.UpdateAt = report.UpdateAt;
            await _db.SaveChangesAsync();
        }
    }
}
