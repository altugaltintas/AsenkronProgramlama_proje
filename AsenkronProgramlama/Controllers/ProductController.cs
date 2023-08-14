using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.Enums;
using AsenkronProgramlama.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {


        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository  _productRepository;
        private readonly IMapper _mapper;

        public ProductController(ICategoryRepository categoryRepository,IProductRepository productRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }



        public async Task <IActionResult> Create()
        {

            ///bura category repoya ihtiyacım doğdu. bunu ctorda di ile alacağım

            //Not: normalde SelectListItem nesnelerini bir listeye doldurarak ve her bir kategori nesnesinden bir SelectListItem nesnesi oluşturarak da bu işlemi yapabilirdik. buda farklı bir yöntem olarak burada kalsın
            await FillCategories();     //alttaki satırı metot haline gitridk bu yüzden sadece metotu cağırdım
            
            //ViewBag.Categories = new SelectList(await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");//pasive olmayan tüm kategorileri göndermem lazım listeyi dolduruken içerdeki id yi id kabul et namei ni text kabul et gibi düşün.

            return View();

        }


        async Task FillCategories()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");

        }


        [HttpPost]

        public async Task <IActionResult> Create (CreateProductVM vM)
        {
            if (ModelState.IsValid)
            {
                Product nesne = await _productRepository.GetByDefault(a=> a.Slug == vM.Slug);
                if (nesne==null)
                {
                    //Product product = new Product();
                    //product.Name = vM.Name;
                    //product.Description = vM.Description;
                    //product.Stock = vM.Stock;
                    //product.CategoryID = vM.CategoryID;
                    //product.Category = await _categoryRepository.GetById(vM.CategoryID);


                    //ben sana CreateProductVM nesnesi verdiğimde sen bakara Product ekle demem lazım. mapper ile gideceğim
                    Product product = _mapper.Map<Product>(vM);
                    //Category nesnesini göremiyor mapper onu yapamıyor. bunu benim yazmam lazım
                    product.Category = await _categoryRepository.GetById(vM.CategoryID);
                    await _productRepository.Add(product);                       //üstteki 6 satırı yazmaktansa  mapper kütüphanesi ile 3 satırda çözebilirsiniz

                    return RedirectToAction("List");
                }


            }

            await FillCategories();
            return View(vM);
        }

        public async  Task <IActionResult> List()
        {
            var list = await _productRepository.GetFilter
                (
                selector: a => new ProductVM { Name = a.Name, ProductID = a.ID, Statu = a.Statu, CategoryName = a.Category.Name, Stock = a.Stock },
                expression: a => a.Statu != Statu.Passive,   // where gibi düşün
                orderBy: a => a.OrderByDescending(a => a.Stock)  // stok miktarına göer sıraladık

                );
            return View(list);
        }

        public  async Task <IActionResult>  Edit (int id)
        { 
            Product product = await _productRepository.GetById(id);

            UpdateProductVM vM =  _mapper.Map<UpdateProductVM>(product);

            await FillCategories();
            return View(vM);
        }


        [HttpPost]


        public async Task <IActionResult> Edit(UpdateProductVM vM) 
        {
            if (ModelState.IsValid)

            {
                
                
                    Product product1= _mapper.Map<Product>(vM);
                    product1.Category=await _categoryRepository.GetById(vM.CategoryID);

                    await _productRepository.Update(product1);
                    return RedirectToAction("List");
                

            }

            await FillCategories();
            return View(vM);
        }


        public async Task <IActionResult> Delete(int id)
        {
            Product product = await _productRepository.GetById(id);

            await _productRepository.Delete(product);

            return RedirectToAction("List");


        }

    }

}
