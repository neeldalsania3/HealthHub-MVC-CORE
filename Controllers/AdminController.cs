using HealthHub_MVC_CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub_MVC_CORE.Controllers
{
    public class AdminController : Controller
    {
        //attribute routing at controller level
        //[route(action/controller/id?)]
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpdateDoctor(string id)
        {
            Doctor doctor = new Doctor();
            Doctor doc = doctor.getData(id);
            return View(doc);
           
        }
        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doc)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = doc.update(doc);
                if (isUpdated)
                {
                    TempData["msg"] = "successfully Updated";
                    return View("Dashboard");
                }
            }
            return View(doc);
        }
        [HttpPost]
        public IActionResult RemoveDoctor(int id)
        {
            Doctor doc = new Doctor();
            bool isDeleted = doc.delete(id);
            return Json(new { success = isDeleted });
        }

        public IActionResult AddAmbulance()
        {
            return View();
        }
       
        [HttpGet]
        public IActionResult UpdateAmbulance(string id)
        {
            Ambulance amb = new Ambulance();
            Ambulance ambulance = amb.getData(id);
            return View(ambulance);
        }
        
        [HttpPost]
        public ActionResult UpdateAmbulance(Ambulance amb)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = amb.update(amb);
                if (isUpdated)
                {
                    TempData["msg"] = "successfully Updated";
                    return View("Dashboard");
                }
            }
            return View(amb);
        }
        [HttpPost]
        public IActionResult RemoveAmbulance(int id)
        {
            Ambulance amb = new Ambulance();
            bool isDeleted = amb.delete(id);
            return Json(new { success = isDeleted });
        }
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(string id)
        {
            Announcement anc = new Announcement();
            Announcement announcement = anc.getData(id);
            return View(announcement);
        }

        [HttpPost]
        public ActionResult UpdateAnnouncement(Announcement anc)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = anc.update(anc);
                if (isUpdated)
                {
                    TempData["msg"] = "successfully Updated";
                    return View("Dashboard");
                }
            }
            return View(anc);
        }
        [HttpPost]
        public IActionResult RemoveAnnouncement(int id)
        {
            Announcement anc = new Announcement();
            bool isDeleted = anc.delete(id);
            return Json(new { success = isDeleted });
        }

        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpdateDepartment(string id)
        {
            Department anc = new Department();
            Department announcement = anc.getData(id);
            return View(announcement);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department anc)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = anc.update(anc);
                if (isUpdated)
                {
                    TempData["msg"] = "successfully Updated";
                    return View("Dashboard");
                }
            }
            return View(anc);
        }
        [HttpPost]
        public IActionResult RemoveDepartment(int id)
        {
            Department anc = new Department();
            bool isDeleted = anc.delete(id);
            return Json(new { success = isDeleted });
        }
        public IActionResult AddMedicine()
        {
            return View();

        }
        [HttpGet]
        public IActionResult UpdateMedicine(string id)
        {
            Medicine anc = new Medicine();
            Medicine announcement = anc.getData(id);
            return View(announcement);
        }

        [HttpPost]
        public ActionResult UpdateMedicine(Medicine anc)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = anc.update(anc);
                if (isUpdated)
                {
                    TempData["msg"] = "successfully Updated";
                    return View("Dashboard");
                }
            }
            return View(anc);
        }
        [HttpPost]
        public IActionResult RemoveMedicine(int id)
        {
            Medicine anc = new Medicine();
            bool isDeleted = anc.delete(id);
            return Json(new { success = isDeleted });
        }
        public IActionResult AddAppoinment()
        {
            return View();
        }
        public IActionResult UpdateAppoinment(string id)
        {
            Appointment anc = new Appointment();
            Appointment Appointment = anc.getData(id);
            return View(Appointment);
        }

        [HttpPost]
        public ActionResult UpdateAppointment(Appointment anc)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = anc.update(anc);
                if (isUpdated)
                {
                    TempData["msg"] = "successfully Updated";
                    return View("Dashboard");
                }
            }
            return View(anc);
        }
        [HttpPost]
        public IActionResult RemoveAppointment(int id)
        {
            Appointment anc = new Appointment();
            bool isDeleted = anc.delete(id);
            return Json(new { success = isDeleted });
        }

        [HttpGet]
        public IActionResult ListofactiveAppointments()
        {
            List<Appointment> appointments = appObj.getData();
            return View(appointments);
        }
       
        public IActionResult ListofAmbulance()
        {
            List<Ambulance> ambulances = ambObj.getData();
            return View(ambulances);
        }
       
        public IActionResult ListofAnnouncement()
        {
            List<Announcement> announcements = ancObj.getData();
            return View(announcements);
        }
        
        public IActionResult ListofDepartment()
        {
            List<Department> departments = depObj.getData();
            return View(departments);
        }
        
        public IActionResult ListofMedicine()
        {
            List<Medicine> medicines = medObj.getData();
            return View(medicines);
        }
        
        public IActionResult ListofDoctor()
        {
            List<Doctor> doctors = docObj.getData();
            return View(doctors);
        }
        
        public IActionResult Dashbord()
        {
            return View("Dashboard");
        }
        public IActionResult ListofpendingAppoinment()
        {
            List<Appointment> appointments = appObj.getData();
            return View(appointments);
        }
        Ambulance ambObj = new Ambulance();
        [HttpPost]
      
        public IActionResult AddAmbulance(Ambulance amb)
        {

            bool res;
            ambObj = new Ambulance();
            res = ambObj.InsertAmbulance(amb);
            if (res)
            {
                TempData["msg"] = "Ambulance Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");
        }
        Announcement ancObj = new Announcement();
        [HttpPost]
        
        public IActionResult AddAnnouncement(Announcement anc)
        {

            bool res;
            ancObj = new Announcement();
            res = ancObj.AddAnnouncement(anc);
            if (res)
            {
                TempData["msg"] = "Announcement Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");
        }

        Appointment appObj = new Appointment();
        [HttpPost]
        public IActionResult AddAppoinment(Appointment app)
        {

            bool res;
            appObj = new Appointment();
            res = appObj.AddAppoinment(app);
            if (res)
            {
                TempData["msg"] = "Appoinment Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");
        }
        Department depObj = new Department();
        [HttpPost]
        
        public IActionResult AddDepartment(Department dep)
        {

            bool res;
            depObj = new Department();
            res = depObj.AddDepartment(dep);
            if (res)
            {
                TempData["msg"] = "Department Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");
        }
        Medicine medObj = new Medicine();
        [HttpPost]
        
        public IActionResult AddMedicine(Medicine med)
        {

            bool res;
            medObj = new Medicine();
            res = medObj.AddMedicine(med);
            if (res)
            {
                TempData["msg"] = "Medicine Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");
        }
        Doctor docObj = new Doctor();
        [HttpPost]
       
        public IActionResult AddDoctor(Doctor doc)
        {

            bool res;
            docObj = new Doctor();
            res = docObj.AddDoctor(doc);
            if (res)
            {
                TempData["msg"] = "Doctor Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");

        }
    }
}

