using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddBookDTO
    {
        //public string PhotoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string? SalePrice { get; set; }
        public bool isStock { get; set; }
        public bool isTranslate { get; set; }
        public bool isSale { get; set; }
        public string Translator { get; set; }
        public string BookCover { get; set; }
        public string PaperType { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
        public List<BookPictureDTO> BookPictures { get; set; }
    }
}
