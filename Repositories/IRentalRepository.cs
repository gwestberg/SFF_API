using System.Collections.Generic;
using System.Threading.Tasks;
using SFF_API.Models;
using System.Xml.Linq;


namespace SFF_API.Repositories
{
    public interface IRentalRepository
    {
        Task<Rental> RentAMovie(Rental rental);
        Task<IEnumerable<Movie>> GetRentableMovies();
        Task <IEnumerable<Rental>> GetRentals();
        Task<Rental> GetRental(int id);
        Task<IEnumerable<Rental>> GetRentalsForStudio(int id);
        Task<Rental> ReturnMovie(int id);
        Task<Label> GetLabelForRental(int id);

    }
}