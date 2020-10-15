using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
    }
}
