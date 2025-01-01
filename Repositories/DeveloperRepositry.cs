using Microsoft.EntityFrameworkCore;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class DeveloperRepositry : IDeveloperRepositry
    {


        private readonly ApplicationDbContext _context;


        public DeveloperRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public Developer GetById(int id)
        {
            try
            {
                return _context.Developer.FirstOrDefault(c => c.DeveloperID == id && !c.IsDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error happen while retrieving the Developer with ID {id}.", ex);
            }
        }
        public void Add(Developer developer)
        {
            try
            {
                _context.Developer.Add(developer);
                _context.SaveChanges(); // Saves changes  after adding
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database Update Exception: {dbEx.Message}");
                Console.WriteLine($"Inner exception: {dbEx.InnerException?.Message}");
                throw new Exception("Database error while adding a new developer.", dbEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                throw new Exception("An error occurred while adding a new client.", ex);
            }
        }


    }
}
