using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.DTOs;
using AsenkronProgramlama.Models.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AsenkronProgramlama.Models.Enums;

namespace AsenkronProgramlama.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)  //mapperı contructor ekledik
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public IActionResult Create()=> View();


        [HttpPost]
        public async Task <IActionResult> Create(CreateCategoryDTO dTO)
        {
            if (ModelState.IsValid)
            {
                Category nesne = await _categoryRepository.GetByDefault(a=> a.Slug == dTO.Slug);   // içeride bu isimde bir kayıt var demektir

                if (nesne==null)
                {

                    //Category category = new Category();
                    //category.Name = dTO.Name;
                    //category.Slug = dTO.Slug;    tek tek yazmak yerine alttaki mapper kuütüphanesi kullanılır


                    Category category = _mapper.Map<Category>(dTO);   //mapper kütüphanesi 


                    await _categoryRepository.Add(category);
                     return RedirectToAction("List");

                }


            }
            return View(dTO);
        }

        public  async  Task <IActionResult> List()
        {
            var categoryList = await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive);
            return View(categoryList);

        }

        public async Task <IActionResult> Edit(int id)
        {
            Category category =await _categoryRepository.GetById(id);

            var model = _mapper.Map<UpdateCategoryDTO>(category);

           


            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> Edit(UpdateCategoryDTO dTO)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryRepository.GetByDefault(a => a.Slug == dTO.Slug);

                if (category==null)
                {
                    var nesne = _mapper.Map<Category>(dTO);
                    await _categoryRepository.Update(nesne);
                    return RedirectToAction("List");
                }

            }
            return View(dTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryRepository.GetByDefault(a => a.ID == id);
            await _categoryRepository.Delete(category);
            return RedirectToAction("List");
        }



    }
}
