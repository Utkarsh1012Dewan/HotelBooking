using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models;
using HotelBookingAPI.Data;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {   
            //denotes a private variable
            _context = context; 
        }

        // Create/Edit
        // Create
        [HttpPost]
        public JsonResult Create(HotelBooking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        // Edit
        // Edit
        // Edit
        [HttpPut("{id}")]
        public JsonResult Edit(int id, HotelBooking booking)
        {
            var bookingInDb = _context.Bookings.Find(id);

            if (bookingInDb == null)
                return new JsonResult(NotFound());

            // Update properties of bookingInDb from booking
            bookingInDb.RoomNumber = booking.RoomNumber;
            bookingInDb.ClientName = booking.ClientName;
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        [HttpGet]

        public JsonResult get(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        //Delete 
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);

            if(result == null)
            {
                return new JsonResult(NotFound());
            }

            else
            {
                _context.Bookings.Remove(result);

                _context.SaveChanges();
            }

            return new JsonResult(Ok(result));

        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
     
    }
     

}
