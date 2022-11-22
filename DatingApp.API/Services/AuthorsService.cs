using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;
using DatingApp.API.Interface;
using DatingApp.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Services
{
    public class AuthorsService : IAuthorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AuthorsService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        //public AuthorWithBookDto GetAuthorWithBooks (int authorId)
        //{
        //    var _author = _context.Authors.Where(n => n.Id == authorId).Select(n=> new AuthorWithBookDto(){
        //        FullName = n.FullName,
        //        BookTitles = n.Book_Authors.Select(n=> n.Book.Title).ToList()
        //    }).FirstOrDefault();

        //    return _author;
        //}

        public async Task<int>  AddAuthorAsync(AuthorDto model)
        {
            if (model == null) return -1;

            var _author = new Author()
            {
                FullName = model.FullName
            };
            _context.Authors.Add(_author);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return -1;
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task<IEnumerable<AuthorVM>> GetAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            if (authors == null) return new List<AuthorVM>();

            var authorsVM = _mapper.Map<IEnumerable<AuthorVM>>(authors);

            return authorsVM;
        }

        public async Task<AuthorVM> GetByIdAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return new AuthorVM();
            var res = _mapper.Map<AuthorVM>(author);
            return res;

        }
            public async Task<int> UpdateAuthorAsync(int id, AuthorDto model)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return -1;
            author.FullName = model.FullName;
            await _context.SaveChangesAsync();
            return author.Id;
        }

       
    }
}