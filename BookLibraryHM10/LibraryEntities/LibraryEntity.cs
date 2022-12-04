using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryEntities;
using Newtonsoft.Json;

namespace LibraryEntities
{
    public class LibraryEntity : BaseEntity, IEntity
    { 
        public string? Name { get; set; }
    }
}
