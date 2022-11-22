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
    public class PublishersService : IPublisherService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PublishersService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public void AddPublish(PublisherDto publishdto)
        //{
        //    var _publisher = new Publisher(){
        //            Name = publishdto.Name
        //        };
        //        _context.Publishers.Add(_publisher);
        //        _context.SaveChanges();
        //}

        //public PublisherWithBooksandAuthorsDto GetPublisherData (int publisherId)
        //{
        //    var _publisherData = _context.Publishers.Where(n=> n.Id == publisherId)
        //                                .Select( n => new PublisherWithBooksandAuthorsDto(){
        //                                    Name = n.Name,
        //                                    BookAuthors = n.Books.Select(n => new BookWithAuthorDto()
        //                                    {
        //                                        BookName = n.Title,
        //                                        BookAuthors = n.Book_Authors.Select(n=>n.Author.FullName).ToList()
        //                                    }).ToList()

        //                                }).FirstOrDefault();
        //    return _publisherData;
        //}

        //public void DeletePublisherById(int id)
        //{
        //   var _publisher =  _context.Publishers.FirstOrDefault(n=> n.Id == id);
        //   if (_publisher != null) 
        //   {
        //    _context.Publishers.Remove(_publisher);
        //    _context.SaveChanges();
        //   } 
        //}

        public async Task<int> AddPublisherAsync(PublisherDto model)
        {
            if (model == null) return -1;

            var _publisher = new Publisher
            {
                Name = model.Name
            };
            _context.Publishers.Add(_publisher);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<IEnumerable<PublisherVM>> GetAllAsync()
        {
            var publishers = await _context.Publishers.ToListAsync();
            if (publishers == null) return new List<PublisherVM>();

            var res = _mapper.Map<IEnumerable<PublisherVM>>(publishers);

            return res;
        }

        public async Task<int> UpdatePublisherAsync(int id, PublisherDto model)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(a => a.Id == id);
            if (publisher == null) return -1;
            publisher.Name = model.Name;
            await _context.SaveChangesAsync();
            return publisher.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(a => a.Id == id);
            if (publisher == null) return -1;
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return publisher.Id;
        }

        public async Task<PublisherVM> GetByIdAsync(int id)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(a => a.Id == id);
            if (publisher == null) return new PublisherVM();
            var res = _mapper.Map<PublisherVM>(publisher);
            return res;
        }
    }
}