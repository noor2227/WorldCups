using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;
using WorldCups.Data;
using WorldCups.Models;
using WorldCups.Views.Home;

namespace WorldCups.Controllers
{//هذا كودي
   
        public class DashBoardController : Controller
        {
        private readonly ApplicationDibContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public DashBoardController(ApplicationDibContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }
            public IActionResult Index()
            {
                return View();
            }

       
        public IActionResult CreateNewCategories(Categries categries)
        {
            _context.Add(categries);
            _context.SaveChanges();

            return RedirectToAction("Categories");
        }
        // حذف 

        public IActionResult DeleteCategries(int id)
        {
            var Categries = _context.Categries.SingleOrDefault(c => c.Id == id);//search
            if (Categries != null)
            {
                _context.Categries.Remove(Categries);
                _context.SaveChanges();
            }
            return RedirectToAction("Categries");
        }
        //حذف
        public IActionResult CreateNewCatogorisTransportation(CatogorisTransportation catogorisTransportation)
        {
            _context.Add(catogorisTransportation);
            _context.SaveChanges();
            return RedirectToAction("CatogorisTransportation");

        }
        public IActionResult Categries()
        {
            var getdata = _context.Categries.ToList();
            return View(getdata);
        }
        //edit
        public IActionResult EditeCategries(int id)
        {
            var edit_Categries = _context.Categries.SingleOrDefault(e => e.Id == id);
            return View(edit_Categries);
            //puddate


        }

        public IActionResult UpdateCategory(Categries Categries)
        {
            if (Categries == null)
            {
                return Content("Category Not Provided");
            }


            _context.Categries.Update(Categries);
            _context.SaveChanges();
            return RedirectToAction("Categries");
        }




        //edit حق افئات
        public IActionResult CatogorisTransportation()
        {
            var getdata = _context.CatogorisTransportation.ToList();

            return View(getdata);
        }

        public IActionResult CreateNewHotel(Hotel hotel,IFormFile photo)
        {
            if(photo == null  || photo.Length == 0){
                return Content("File Not Select");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using(FileStream straem= new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();

            }
            hotel.Images = photo.FileName;
            _context.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Hotel");

        }


        public IActionResult DeleteHotel(int id)
        {
            var Hotel = _context.Hotel.SingleOrDefault(c => c.Id == id);//search
            if (Hotel != null)
            {
                _context.Hotel.Remove(Hotel);
                _context.SaveChanges();
            }
            return RedirectToAction("Hotel");
        }



        public IActionResult Hotel()
        {
            var getdata = _context.Hotel.ToList();

            return View(getdata);

        }
        //اديت تعديل

        public IActionResult EditeHotel(int id)
        {
            var edit_Hotel = _context.Hotel.SingleOrDefault(e => e.Id == id);
            return View(edit_Hotel);
           
        }

        //ابديت هنا
        public IActionResult UpdateHotel(Hotel Hotel, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Select");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using (FileStream straem = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();

            }

            Hotel.Images = photo.FileName; 
            _context.Hotel.Update(Hotel);
            _context.SaveChanges();
            return RedirectToAction("Hotel");
        }








        //public IActionResult Transport()
        //{
        //var getdata = _context.Transport.ToList();
        //ViewBag.getdata = getdata;


        /*var Transport = _context.Transport.ToList();
         var GetCatogorisTransportation = _context.Transport.Join{
            Transport=> Transport vehicle,
            CatogorisTransportation => CatogorisTransportation.Id,
            (Transport,CatogorisTransportation )=>new{
                 Id =Transport.Id,
                 NameCar=Transport.Name
                 Model=Transport.Model
                }


          }).ToList();
           ViewBage.getdataTransport= GetDataTransport;

         */


        //return View();
        //}

        /*/حذف
        public IActionResult DeleteCategries(int id)
        {
            var Categries = _context.Categries.SingleOrDefult(categries.Id == id);
            if(Categries != null)
            {
                _context.Categries.Remove(ategries);
                _context.SaveChanges();

            }
        }*/


        /*public IActionResult CreateNewTransport(Transport transport,IFormFile photo )
        {
            if(photo == null || photo.Length==0)
            {
                return Content("No File Select ");
            }
            //wwwwroot/images/p.png
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using (FileStream straem = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();
            }
            
            transport.Images = photo.FileName;
            _context.Add(transport);
            _context.SaveChanges();
            return Redirect("Transport");

        }
        */








        public IActionResult CreateNewTransport(Transport transport, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Select");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using (FileStream straem = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();

            }
            transport.Images = photo.FileName;
            _context.Add(transport);
            _context.SaveChanges();
            return RedirectToAction("Transport");

        }
        public IActionResult Transport()
        {
            var getdata = _context.Transport.ToList();
            ViewBag.getdata = getdata;
            return View();
        }
        //حذف النقل
        public IActionResult DeleteTransport(int id)
        {
            var Transport = _context.Transport.SingleOrDefault(c => c.Id == id);//search
            if (Transport != null)
            {
                _context.Transport.Remove(Transport);
                _context.SaveChanges();
            }
            return RedirectToAction("Transport");
        }
        //ابديت النقل 

        public IActionResult EditeTransport(int id)
        {
            var edit_Transport = _context.Transport.SingleOrDefault(e => e.Id == id);
            return View(edit_Transport);
            //puddate


        }
        //puddate
        public IActionResult UpdatesTransport(Transport Transport, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Select");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using (FileStream straem = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();

            }


            Transport.Images = photo.FileName;
            _context.Transport.Update(Transport);
            _context.SaveChanges();
            return RedirectToAction("Transport");

        }

        //ابديت النقل النقل النقل


        //studiums
        public IActionResult CreateNewstudium1(studium1 studium, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Select");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using (FileStream straem = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();

            }
            //ادخال جميع القيم
           
                studium.Iamges = photo.FileName;
                _context.Add(studium);
                _context.SaveChanges();
                
                return RedirectToAction("studium1");

            
          
            return View("studium1");
        }
           //


        
        public IActionResult studium1()
        {
            var getdata = _context.studium1.ToList();

            return View(getdata);

        }//studium1 studium1 studium1 studium1


        //tableFootbul  tableFootbul  tableFootbul 
        public IActionResult TableFootbul()
        {
            var getdata = _context.studium1.ToList();
            ViewBag.getdata = getdata;
            var tableFootbul = _context.TableFootbul.ToList();//read from tableFootbul table

            var getdatatableFootbul = _context.TableFootbul.Join(

                _context.studium1, 
                
                TableFootbul => TableFootbul.studium1_id, 

                studium1 => studium1.Id, 

                (TableFootbul, studium1) => new 
                { Id = TableFootbul.Id,
                    NameA = TableFootbul.Name,
                    NameB = studium1.Name, 
                    City = TableFootbul.Ctiy, 
                    Ateam1 = TableFootbul.Ateam1,
                    Ateam2 = TableFootbul.Ateam2, 
                    MatchTimeA = TableFootbul.MatchTime 
                }).ToList();
            ViewBag.getdataTableFootbul = getdatatableFootbul;

            return View(tableFootbul);
        }

        public IActionResult CreateNewTableFootbul(TableFootbul tableFootbul)
        {
            //ادخال البيانات


            if (ModelState.IsValid)
            {
                _context.Add(tableFootbul);
                _context.SaveChanges();
                TempData["Save"] = "تمت عملية الحفظ";
                return RedirectToAction("studium1");
            }
            TempData["Save"] = "لم عملية الحفظ";
            return View("TableFootbul");


        }
        public IActionResult DeleteTableFootbul(int id)
        {
            var TableFootbul = _context.TableFootbul.SingleOrDefault(c => c.Id == id);//search
            if (TableFootbul != null)
            {
                _context.TableFootbul.Remove(TableFootbul);
                _context.SaveChanges();
            }
            return RedirectToAction("TableFootbul");
        }

        //tableFootbul  tableFootbul  tableFootbul 
        public IActionResult EditeTableFootbul(int id)
        {
            var edit_TableFootbul = _context.TableFootbul.SingleOrDefault(e => e.Id == id);
            return View(edit_TableFootbul);
            //puddate


        }

        public IActionResult UpdateTableFootbul(TableFootbul TableFootbul)
        {
          
            
                return Content("TableFootbul Not Provided");
            


            _context.TableFootbul.Update(TableFootbul);
            _context.SaveChanges();
            return RedirectToAction("TableFootbul");
        }



        //tableFootbul  tableFootbul  tableFootbul 




        //edit حق افئات

        //Delete

        public IActionResult Deletestudium1(int id)
        {
            var studium1 = _context.studium1.SingleOrDefault(c => c.Id == id);//search
            if (studium1 != null)
            {
                _context.studium1.Remove(studium1);
                _context.SaveChanges();
            }
            return RedirectToAction("studium1");
        }
        //edite 
        public IActionResult Editestudium1(int id)
        {
            var edit_studium1 = _context.studium1.SingleOrDefault(e=>e.Id==id);
            return View(edit_studium1);
            //puddate
           

    }
        //puddate
       public IActionResult Updatestudium1(studium1 studium1, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Select");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "iamges", photo.FileName);//path
            using (FileStream straem = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(straem);
                straem.Close();

            }
            

            studium1.Iamges = photo.FileName;
            _context.studium1.Update(studium1);
            _context.SaveChanges();
            return RedirectToAction("studium1");

        }


    }
}









