using SupportProductsEvaluation.Core.Entities;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface ICommentService
    {
        Task Add(Comment comment);
    }
}
