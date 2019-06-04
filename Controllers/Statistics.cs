using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hr_management_system.Models;
using Hr_management_system.Repository;
using Hr_management_system.Services;

namespace Hr_management_system.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StatisticsController : Controller
    {

        #region Database init

           private hr_databaseContext db = new hr_databaseContext();

        #endregion 
        public StatisticsController(hr_databaseContext _db)
        {
            this.db = _db;
        }

        // api/statistics/all
        [HttpGet]
        [ActionName("all")]
        public JsonResult GetStatistics()
        {
            var cityList = db.EmployeeInfo.Select( query => new { city = query.City });

            var countryList = db.EmployeeInfo.Select( query => new { country = query.Country });

            var salary = db.Employees.Select( query => new { salary = query.Salary });

            var ageList = db.EmployeeInfo.Select( query => new { age = query.Age });

            var maleFemale = db.EmployeeInfo.Select( query => new { sex = query.Sex });

            var totalEmployees = db.Employees.Count();

            var serializable = new { employeesTotal = totalEmployees, cities = cityList, countries = countryList, salaries = salary, age = ageList , genders = maleFemale };

            Logging.writeToLog("api/statistics/all", Request.Method);

            return Json(serializable);
        }
    }
}