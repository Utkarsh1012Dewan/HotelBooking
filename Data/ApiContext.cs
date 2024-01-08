using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Data
{
    public class ApiContext : DbContext
    {
        //DbSet willl be used to store hotel bookings in an In-Memory space
        public DbSet<HotelBooking> Bookings { get; set; } 
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}
