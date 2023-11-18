using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class BookDal : EfEntityRepositoryBase<Book, KibritBookDbContext>, IBookDal
    {
        public BookDTO FindById(int id)
        {
            using (KibritBookDbContext context = new())
            {
                var product = context.Books.Include(x => x.Author).Include(x=>x.Genre).Include(x=>x.Language).Include(x=>x.Publisher).FirstOrDefault(x => x.Id == id);
                var productPictures = context.BookPictures.Where(x => x.BookId == id).ToList();
                var comments = context.Comments.Where(x => x.BookId == product.Id).ToList();


                decimal ratingSum = 0;
                int ratingCount = 0;

                List<CommentDTO> commentResult = new();

                for (int i = 0; i < comments.Count; i++)
                {
                    CommentDTO comment = new()
                    {
                        BookId = product.Id,
                        UserEmail = comments[i].UserEmail,
                        UserName = comments[i].UserName,
                        Ratings = comments[i].Ratings,
                        Review = comments[i].Review
                    };
                    commentResult.Add(comment);
                }

                List<string> pictures = new();

                foreach (var picture in productPictures)
                {
                    pictures.Add(picture.PhotoURL);
                }
                foreach (var rating in comments.Where(x => x.Ratings != 0))
                {
                    ratingCount++;
                    ratingSum += rating.Ratings;
                }

                if (ratingCount == 0)
                    ratingSum = 0;
                else
                    ratingSum = ratingSum / ratingCount;


                BookDTO result = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    AuthorName = product.Author.Name,
                    PublisherName = product.Publisher.Name,
                    GenreName = product.Genre.Name,
                    LanguageName = product.Language.Name,
                    Price = product.Price,
                    SalePrice = product.SalePrice,
                    //PhotoURL = product.PhotoURL,
                    Translator = product.Translator,
                    ReviewCount = ratingCount,
                    Size = product.Size,
                    PaperType = product.PaperType,
                    BookPictures = pictures,
                    BookCover = product.BookCover,
                    isStock = product.isStock,
                    isTranslate = product.isTranslate,
                    isSale = product.isSale,
                    Rating = Math.Round(ratingSum, 1),
                    Comments = commentResult,
                    Quantity = product.Quantity,
                };

                return result;
            }
        }

        public List<BookDTO> GetAllBook()
        {
            using (KibritBookDbContext context = new())
            {
                var products = context.Books.Include(x => x.Author).Include(x => x.Genre).Include(x => x.Language).Include(x => x.Publisher).Include(x => x.BookPicture).ToList();
                var productPictures = context.BookPictures;

                var ratings = context.Comments;



                List<BookDTO> result = new();



                for (int i = 0; i < products.Count; i++)
                {
                    decimal ratingSum = 0;
                    int ratingCount = 0;
                    List<string> pictures = new();

                    foreach (var item in productPictures.Where(x => x.BookId == products[i].Id))
                    {
                        pictures.Add(item.PhotoURL);
                    }

                    foreach (var rating in ratings.Where(x => x.BookId == products[i].Id && x.Ratings != 0))
                    {

                        ratingCount++;
                        ratingSum += rating.Ratings;
                    }

                    if (ratingCount == 0)
                    {
                        ratingSum = 0;
                    }
                    else
                    {
                        ratingSum = ratingSum / ratingCount;
                    }



                    BookDTO productList = new()
                    {
                        Id = products[i].Id,
                        Name = products[i].Name,
                        Description = products[i].Description,
                        AuthorName = products[i].Author.Name,
                        PublisherName = products[i].Publisher.Name,
                        GenreName = products[i].Genre.Name,
                        LanguageName = products[i].Language.Name,
                        Price = products[i].Price,
                        SalePrice = products[i].SalePrice,
                        //PhotoURL = products[i].PhotoURL,
                        Translator = products[i].Translator,
                        ReviewCount = ratingCount,
                        Size = products[i].Size,
                        PaperType = products[i].PaperType,
                        BookPictures = pictures,
                        BookCover = products[i].BookCover,
                        isStock = products[i].isStock,
                        isTranslate = products[i].isTranslate,
                        isSale = products[i].isSale,
                        Rating = Math.Round(ratingSum, 1),
                        Quantity = products[i].Quantity,
                    };
                    result.Add(productList);
                }
                return result;
            }
        }
    }
}
