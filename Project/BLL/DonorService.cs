using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public class DonorService : IDonorService
    {
        private readonly IDonorDal donorDal;
        public DonorService(IDonorDal donorDal)
        {
            this.donorDal = donorDal;
        }
        public async Task<Donor> Add(Donor donor)
        {

            return await donorDal.Add(donor);
        }
        public async Task<List<Donor>> GetAllDonor()
        {
            return await donorDal.GetAllDonor();
        }

        public async Task<List<Present>> GetPresentByDonor(string donorName)
        {
            return await donorDal.GetPresentByDonor(donorName);
        }
        public async Task<Donor> GetDonorByMail(string Mail)
        {
            return await donorDal.GetDonorByMail(Mail);
        }
        public async Task<Donor> GetDonorByName(string Name)
        {
            return await donorDal.GetDonorByName(Name);
        }
        public async Task<Donor> UpdateDonor(DonorDto donor, int id)
        {
            return await donorDal.UpdateDonor(donor, id);
        }
    }
}

