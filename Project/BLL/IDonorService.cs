using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public interface IDonorService
    {

        Task<Donor> Add(Donor donor);
        Task<List<Donor>> GetAllDonor();
        public Task<List<Present>> GetPresentByDonor(string donorName);

        public Task<Donor> GetDonorByMail(string Mail);
        public Task<Donor> GetDonorByName(string Name);
        public Task<Donor> UpdateDonor(DonorDto donor, int id);
    }
}
