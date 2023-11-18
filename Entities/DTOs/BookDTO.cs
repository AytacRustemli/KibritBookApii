using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        //public string PhotoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string? SalePrice { get; set; }
        public int Quantity { get; set; }
        public bool isStock { get; set; }
        public bool isTranslate { get; set; }
        public bool isSale { get; set; }
        public int ReviewCount { get; set; }
        public decimal Rating { get; set; }
        public string Translator { get; set; }
        public string BookCover { get; set; }
        public string PaperType { get; set; }
        public string Size { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string GenreName { get; set; }
        public string LanguageName { get; set; }
        public List<string> BookPictures { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
