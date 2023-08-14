using System.ComponentModel.DataAnnotations;

namespace AsenkronProgramlama.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        // kimi güncelleyeğimi bilmek için id bilgisi  forma gömeğim ve esas postta kullanacağım

        public int Id { get; set; }



        [Required(ErrorMessage ="bu Alan boş bırakılamaz")]
        [MinLength(3,ErrorMessage ="En az 3 karakter olmalı")]
        public string Name { get; set; }

         public string Slug => Name.ToLower().Replace("_", "-");


    }
}
