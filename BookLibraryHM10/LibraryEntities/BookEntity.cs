using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class BookEntity: BaseEntity, IEntity
    {
        public string? BookName { get; set; }

        public string? BookAuthor { get; set; }
        
        public string? BookGenre { get; set; }
        
        public int? YearPublication { get; set; }

        public int LibraryId { get; set; }

    }
}

