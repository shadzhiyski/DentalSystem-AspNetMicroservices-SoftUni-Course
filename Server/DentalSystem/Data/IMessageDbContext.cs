using DentalSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalSystem.Data
{
    public interface IMessageDbContext
    {
        DbSet<Message> Messages { get; set; }
    }
}