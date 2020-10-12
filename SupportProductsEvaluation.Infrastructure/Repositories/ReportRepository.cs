﻿using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System.Collections.Generic;
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
        public async Task<Report> Get(Report report)
                => await _db.Report.SingleOrDefaultAsync(r => r.ProductName==report.ProductName&&r.SubCategoryName==report.SubCategoryName&&
                                                         r.CategoryName==report.CategoryName);

        public async Task<IList<Report>> GetAll()
                => await _db.Report.AsQueryable().ToListAsync();

        public async Task Update(Report report)
        {
            var reportEntity = await Get(report);
            reportEntity.AvgPrice = report.AvgPrice;
            reportEntity.AvgRate = report.AvgRate;
            reportEntity.CategoryName = report.CategoryName;
            reportEntity.ProductName = report.ProductName;
            reportEntity.SubCategoryName = report.SubCategoryName;
            reportEntity.UpdateAt = report.UpdateAt;
            await _db.SaveChangesAsync();
        }
    }
}
