using AsenkronProgramlama.Models.Entities.Abstract;

namespace AsenkronProgramlama.Models.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        //navigation
        //bir productın bir karegorisi olur. bir id ve nesne barındırmam lazım
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }//virtual lazy loading yaptığım için virtual işaretledim

    }
}