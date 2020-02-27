namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using EBook.Services.Contracts.Convert;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBookRepositoryService : IEBookRepositoryService
    {
        private IEBooksRepository _eBookRepository;
        private IFilePdfConverter _pdfConverter;

        public EBookRepositoryService(IEBooksRepository eBooksRepository, IFilePdfConverter pdfConverter)
        {
            _eBookRepository = eBooksRepository;
            _pdfConverter = pdfConverter;
        }

        public async Task<Book> Create(Book book)
        {
            var file = await _pdfConverter.Convert(book.File.Path);

            book.File.Content = file.Content;
            var createdBook = await _eBookRepository.Create(book);
            
            return createdBook;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
