﻿using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Add(Comment comment)
        {
            if (comment is null)
            {
                throw new ArgumentNullException("comment doesn't exist");
            }

            await _commentRepository.Add(comment);
        }

        public async Task Delete(int? id)
        {
            var commentEntity= await _commentRepository.Get(id.Value);
            if(commentEntity is null)
            {
                throw new ArgumentNullException("comment doesn't exist");
            }

            await _commentRepository.Delete(commentEntity);
        }

        public async Task<IList<Comment>> GetPaginated(Expression<Func<Comment, bool>> filter=null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return await _commentRepository.GetPaginated(c => true, pageSize, productPage);
            }

            return await _commentRepository.GetPaginated(filter, pageSize, productPage);
        }

    }
}
