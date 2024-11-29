using LearningProject2.Data;
using LearningProject2.DTO;
using LearningProject2.Models;
using LearningProject2.Interfaces;
using LearningProject2.Repositories;

namespace LearningProject2.Services;

public class BandService(IBandRepository bandRepository):IBandService
{
    
    
    //Geth IServices
    public async Task<List<Band>> ConsultAllBands()
    {
        return await bandRepository.GetAllBands();
        
    }


    public async Task<Band> ConsultBandById(int Id)
    {
         return await bandRepository.GetBandById(Id);
        
    }

    public async Task<List<Band>> ConsultBandByCountry(string Id)
    {
        return  await bandRepository.GetBandByCountry(Id);
        
    }
    
    //Post IServices
    public async Task<Band> AddBand(Band Band)
    {
        return await bandRepository.InsertBand(Band);
        
    }
    
    //Put IService
    public async Task<Band> UpdateBand(Band Band,int Id)
    {
        return  await bandRepository.UpdateBand(Band, Id);
        
    }
    
    //Delete IService
    public async Task DeleteBandById(int Id)
    {
         await bandRepository.DeleteBandById(Id);
        
    }
    
    
}