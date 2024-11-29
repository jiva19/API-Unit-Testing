using LearningProject2.DTO;
using System.Linq.Expressions;
using LearningProject2.Models;
using LearningProject2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningProject2.Interfaces;

public interface IBandRepository

{   //Get Methods
    Task<List<Band>> GetAllBands();
    
    Task<Band>GetBandById (int id);
    Task<List<Band>> GetBandByCountry(string Country);
    
    //Post IServices
    Task<Band> InsertBand(Band Band);
    
    //Put IService
    Task<Band> UpdateBand(Band Band,int id);
    
    //Delete IService
    Task DeleteBandById(int Id);  
}