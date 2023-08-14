using AsenkronProgramlama.Models.Entities.Abstract;
using System.Collections.Generic;

namespace AsenkronProgramlama.Models.Entities.Concrete
{
    public class Category: BaseEntity
    {


        public string Name { get; set; }

        public string Slug { get; set; }

        //navigation prop

        public List<Product> Products { get; set; }

    }
}
