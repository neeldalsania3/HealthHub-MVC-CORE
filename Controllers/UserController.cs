using HealthHub_MVC_CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub_MVC_CORE.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor context;
        public UserController(IHttpContextAccessor context)
        {
            this.context = context;

        }

        [Route("reg")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("uudash")]
        public IActionResult Dashboard()
        {
            return View();
        }
        
        public IActionResult UserDashboard()
        {
            return View("UserDashboard");
        }
        [Route("log")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("main")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("addapppo")]
        public IActionResult AddAppoinment()
        {
            return View("AddAppoinment");
        }

        UserModel userObj=new UserModel();
        [Route("reg")]
        [HttpPost]
        public IActionResult Adduser(UserModel user)
        {

            bool res;
            userObj = new UserModel();
            res = userObj.Insert(user);
            if (res)
            {
                TempData["msg"] = "Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("UserDashboard");
        }
        [Route("log")]
        [HttpPost]
        public IActionResult LoginUser(UserModel user, string Email)
        {
            if (user.Email == "admin" && user.Password == "123")
            {
                TempData["msg"] = "Logged in successfully as admin";
                context.HttpContext.Session.SetString("Email", Email);
                return View("Dashboard");
            }
            else
            {
                context.HttpContext.Session.SetString("Email", Email);
                TempData["msg"] = "Logged in successfully as user.";
                return View("UserDashboard");
            }
        }
        Appointment appObj = new Appointment();
        [Route("addappo")]
        public IActionResult AddAppoinments(Appointment app)
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
            return View("UserDashboard");
        }
        [Route("lstuacap")]
        [HttpGet]
        public IActionResult ListofactiveAppointments()
        {
            Appointment appObj = new Appointment();
            List<Appointment> appointments = appObj.getData();
            return View(appointments);
        }
        [Route("lstuamb")]
        public IActionResult ListofAmbulance()
        {
            Ambulance ambObj = new Ambulance();
            List<Ambulance> ambulances = ambObj.getData();
            return View(ambulances);
        }
        [Route("lstuanc")]
        public IActionResult ListofAnnouncement()
        {
            Announcement annObj = new Announcement();
            List<Announcement> announcements = annObj.getData();
            return View(announcements);
        }
        [Route("lstudec")]
        public IActionResult ListofDepartment()
        {
            Department depObj = new Department();
            List<Department> departments = depObj.getData();
            return View(departments);
        }
        [Route("lstumed")]
        public IActionResult ListofMedicine()
        {
            Medicine medObj = new Medicine();
            List<Medicine> medicines = medObj.getData();
            return View(medicines);
        }
        [Route("lstudoc")]
        public IActionResult ListofDoctor()
        {
            Doctor docObj = new Doctor();
            List<Doctor> doctors = docObj.getData();
            return View(doctors);
        }
        [Route("lstupend")]
        public IActionResult ListofpendingAppoinment()
        {
            Appointment appObj = new Appointment();
            List<Appointment> appointments = appObj.getData();
            return View(appointments);
        }
    }
}
