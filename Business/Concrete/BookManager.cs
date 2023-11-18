using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BookManager : IBookManager
    {
        private readonly IBookDal _bookDal;
        private readonly IBookPictureManager _bookPictureManager;

        public BookManager(IBookDal productDal, IBookPictureManager productPictureManager)
        {
            _bookDal = productDal;
            _bookPictureManager = productPictureManager;
        }
        public void AddBook(AddBookDTO bookDTO)
        {
            Book book = new()
            {
                Name = bookDTO.Name,
                Description = bookDTO.Description,
                //PhotoURL = bookDTO.PhotoURL,
                Price = bookDTO.Price,
                SalePrice = bookDTO.SalePrice,
                isStock = bookDTO.isStock,
                isTranslate = bookDTO.isTranslate,
                isSale = bookDTO.isSale,
                Translator = bookDTO.Translator,
                BookCover = bookDTO.BookCover,
                PaperType = bookDTO.PaperType,
                Size = bookDTO.Size,
                AuthorId = bookDTO.AuthorId,
                PublisherId = bookDTO.PublisherId,
                GenreId = bookDTO.GenreId,
                LanguageId = bookDTO.LanguageId,
                Quantity = bookDTO.Quantity
            };
            _bookDal.Add(book);
            for (int i = 0; i < bookDTO.BookPictures.Count; i++)
            {
                bookDTO.BookPictures[i].BookId = book.Id;
                _bookPictureManager.AddBookPicture(bookDTO.BookPictures[i]);
            }

        }

        public List<BookDTO> GetAllBookList()
        {
            return _bookDal.GetAllBook();
        }

        public BookDTO GetBookById(int id)
        {
            return _bookDal.FindById(id);
        }

        public void RemoveBook(AddBookDTO bookDTO, int id)
        {
            var current = _bookDal.Get(x=>x.Id == id);
            current.Name = bookDTO.Name;
            current.Description = bookDTO.Description;
            //current.PhotoURL = bookDTO.PhotoURL;
            current.Price = bookDTO.Price;
            current.SalePrice = bookDTO.SalePrice;
            current.isStock = bookDTO.isStock;
            current.isTranslate = bookDTO.isTranslate;
            current.isSale = bookDTO.isSale;
            current.Translator = bookDTO.Translator;
            current.BookCover = bookDTO.BookCover;
            current.PaperType = bookDTO.PaperType;
            current.Size = bookDTO.Size;
            //current.AuthorId = bookDTO.AuthorId;
            //current.GenreId = bookDTO.GenreId;
            //current.PublisherId = bookDTO.PublisherId;
            //current.LanguageId = bookDTO.LanguageId;
            current.Quantity = bookDTO.Quantity;
            _bookDal.Delete(current);
        }

        public void UpdateBook(AddBookDTO bookDTO, int id)
        {
            var current = _bookDal.Get(x => x.Id == id);
            current.Name = bookDTO.Name;
            current.Description = bookDTO.Description;
            //current.PhotoURL = bookDTO.PhotoURL;
            current.Price = bookDTO.Price;
            current.SalePrice = bookDTO.SalePrice;
            current.isStock = bookDTO.isStock;
            current.isTranslate = bookDTO.isTranslate;
            current.isSale = bookDTO.isSale;
            current.Translator = bookDTO.Translator;
            current.BookCover = bookDTO.BookCover;
            current.PaperType = bookDTO.PaperType;
            current.Size = bookDTO.Size;
            //current.AuthorId = bookDTO.AuthorId;
            //current.GenreId = bookDTO.GenreId;
            //current.PublisherId = bookDTO.PublisherId;
            //current.LanguageId = bookDTO.LanguageId;
            current.Quantity = bookDTO.Quantity;
            _bookDal.Update(current);
        }

    }
}
