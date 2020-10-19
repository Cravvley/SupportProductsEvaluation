using SupportProductsEvaluation.Data.Entities;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
    }
}
