﻿using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lab2.Data;

namespace Lab2.Services.Repositories
{
    public class PostsRepositoryService : IRepository<Post>
    {
        private readonly ApplicationDbContext context;

        public PostsRepositoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Post Create(Post entity)
        {
            var entityEntry = context.Posts.Add(entity);
            context.SaveChanges();

            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
        }

        public List<Post> Read(Post filterBy, string orderBy, string order, int page, int perPage)
        {

            return context.Posts.OrderBy(post => post.Id).Skip((page - 1) * perPage).Take(perPage).ToList();
        }

        public Post Read(int id)
        {
            return context.Posts.Include(post => post.Comments).FirstOrDefault(post => post.Id == id);
        }

        public void Update(Post post)
        {
        }

        public int Count(Post filterBy)
        {

            return context.Posts.Count();
        }

        public CommentToPost AddCommentToPost(CommentToPost comment)
        {
            var entityEntry = context.Comments.Add(comment);
            context.SaveChanges();

            return entityEntry.Entity;
        }

        public void UpdateCommentToPost(int id)
        {
        }

        public void DeleteCommentToPost(int id)
        {
        }
        public bool IsAuthorizedToDelete(User user, CommentToPost comment)
        {
            // Логіка перевірки прав доступу користувача
            if (user.isAdmin == true)
            {
                // Адміністратор має право видаляти будь-які публікації та коментарі
                return true;
            }
            if (comment.UserId == user.Id)
            {
                return true;
            }

            return false;
        }
    }
}
