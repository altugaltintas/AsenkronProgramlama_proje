using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AsenkronProgramlama.Models.DTOs
{
    public class CreateCategoryDTO 
    {

        [Required(ErrorMessage ="Bu Alan Boş Olamaz.")]
        [MinLength(3,ErrorMessage ="En Az 3 Karakter Yazınız")]
        public string Name { get; set; }


        public string Slug => Name.ToLower().Replace(' ', '-');
        

       

    }
}
