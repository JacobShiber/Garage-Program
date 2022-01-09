using Garage_Program.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Garage_Program.Controllers.API
{
    public class CarsController : ApiController
    {
        GarageContext dataContext = new GarageContext();

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success!", carsList = dataContext.Cars.ToList() });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch(Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // GET: api/Cars/5
        public IHttpActionResult GetById(int id)
        {
            try
            {
                Car expectedCar = dataContext.Cars.First(car => car.Id == id);

                return Ok(new { Massage = "Success!", expectedCar });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // POST: api/Cars
        public IHttpActionResult AddCar([FromBody]Car newCar)
        {
            try
            {
                dataContext.Cars.Add(newCar);
                dataContext.SaveChanges();

                return Ok(new { Massage = "Success! New car been added" });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // PUT: api/Cars/5
        [HttpPut]
        public IHttpActionResult EditCar(int id, [FromBody]Car editedCar)
        {
            try
            {
                Car expectedCar = dataContext.Cars.Single(car => car.Id == id);
                expectedCar.OwnerName = editedCar.OwnerName;
                expectedCar.CarNumber = editedCar.CarNumber;
                expectedCar.RepairStatus = editedCar.RepairStatus;

                dataContext.SaveChanges();

                return Ok(new { Massage = "Success! Car been edited." });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // DELETE: api/Cars/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.Cars.Remove(dataContext.Cars.Single(car => car.Id == id));
                dataContext.SaveChanges();

                return Ok(new { Massage = "Success! Car been deleted" });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }
    }
}
