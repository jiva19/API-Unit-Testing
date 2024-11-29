using LearningProject2.DTO;
using LearningProject2.Models;
namespace LearningProject2.Interfaces;

public interface IBandService
{
    //Geth IServices
    Task<List<Band>> ConsultAllBands();
    Task<Band> ConsultBandById(int Id);
    Task<List<Band>> ConsultBandByCountry(string Id);
    
    //Post IServices
    Task<Band> AddBand(Band Band);
    
    //Put IService
    Task<Band> UpdateBand(Band Band,int Id);
    
    //Delete IService
    Task DeleteBandById(int Id);
    
}