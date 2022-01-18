using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class WaiterController : ApiController
    {
        RestaurantDB ResturantDB = new RestaurantDB();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(ResturantDB.Waiters.ToList());
            }
            catch(SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public IHttpActionResult Get(int id)
        {

            try
            {
                return Ok(ResturantDB.Waiters.First(waiter => waiter.Id == id));
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

       
        public IHttpActionResult Post([FromBody]Waiter value)
        {

            try
            {
                ResturantDB.Waiters.Add(value);
                ResturantDB.SaveChanges();
                return Ok(ResturantDB.Waiters.ToList());
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public IHttpActionResult Put(int id, [FromBody] Waiter value)
        {
            try
            {
                Waiter waiter = ResturantDB.Waiters.First(waiterx => waiterx.Id == id);
                waiter.WorkHours = value.WorkHours;
                waiter.FirstName = value.FirstName;
                waiter.LastName = value.LastName;
                waiter.BirthDate = value.BirthDate;
                ResturantDB.SaveChanges();
                return Ok(ResturantDB.Waiters.ToList());
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public IHttpActionResult Delete(int id)
        {

            try
            {
                ResturantDB.Waiters.Remove(ResturantDB.Waiters.First(waiter => waiter.Id == id));
                ResturantDB.SaveChanges();
                return Ok(ResturantDB.Waiters.ToList());
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }
    }
}
