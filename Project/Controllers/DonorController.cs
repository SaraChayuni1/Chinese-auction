using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {


        private readonly IDonorService donorService;
        private readonly IMapper mapper;
        //DonorService donorService;

        public DonorController(IDonorService idonorService, IMapper mapper)
        {
            this.donorService = idonorService;
            this.mapper = mapper;

        }
        [Authorize(Roles = "manager")]
        [HttpPost("/Donor/Add")]
        public async Task<Donor> Add(DonorDto donor)
        {
            var p = mapper.Map<Donor>(donor);
            await donorService.Add(p);
            
            return p;
        }
        [HttpGet("/Donor/GetAllDonors")]
        public async Task<List<Donor>> GetAllDonor()
        {
            return await donorService.GetAllDonor();

        }
        [HttpGet("/Donor/{GetPresentByDonor}")]
        public async Task<List<Present>> GetPresentByDonor(string GetPresentByDonor)
        {
            return await donorService.GetPresentByDonor(GetPresentByDonor);
        }
        [HttpGet("/Donor/GetDonorByMail/{GetDonorByMail}")]
        public async Task<Donor> GetDonorByMail(string GetDonorByMail)
        {
            return await donorService.GetDonorByMail(GetDonorByMail);
        }
        [HttpGet("/Donor/{GetDonorByName}")]
        public async Task<Donor> GetDonorByName(string GetDonorByName)
        {
            return await donorService.GetDonorByMail(GetDonorByName);
        }
       
        [HttpPut("/Donor/{id}")]
        [Authorize(Roles= "Manager")]
        public async Task<Donor> UpdateDonor(DonorDto donor, int id)
        {

            return await donorService.UpdateDonor(donor, id);
        }
    }
}

