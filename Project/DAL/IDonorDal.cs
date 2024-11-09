using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface IDonorDal
    {
        public Task<Donor> Add(Donor donor);
        public Task<List<Donor>> GetAllDonor();

        public Task<Donor> UpdateDonor(DonorDto donor, int id);

        public Task<Donor> GetDonorByMail(string Mail);
        public Task<Donor> GetDonorByName(string Name);
        public Task<List<Present>> GetPresentByDonor(string donorName);
    }
}

