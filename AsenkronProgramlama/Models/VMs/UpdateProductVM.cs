using System.ComponentModel.DataAnnotations;

namespace AsenkronProgramlama.Models.VMs
{
    public class UpdateProductVM
    {


        public int ID { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "bu Alan boş bırakılamaz")]
        [Range(0, 30000)]   // 0 ile 30000 arasında data girmesne sebebiyet verir eksi stok giremez
        public int Stock { get; set; }

        [Required(ErrorMessage = "bu Alan boş bırakılamaz")]
        public string Description { get; set; }


        public string Slug => Name.ToLower().Replace(' ', '-');



        //categori için

        [Required(ErrorMessage = "Lütfen Kategori Seçiniz")]
        public int CategoryID { get; set; }
    }
}
