using LearningProject2.Data;
using LearningProject2.Properties.CustomException;
using LearningProject2.DTO;
using LearningProject2.Models;
using LearningProject2.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LearningProject2.Repositories;

public class BandRepository(DataContext _context): IBandRepository
{/*
    private readonly DataContext _context;
    public BandRepository(DataContext context)
    {
        _context = context;
    }*/
    
    //Get Methods
    public async Task<List<Band>> GetAllBands()
    {
        var bands_List = await _context.Bands.ToListAsync();
        return bands_List;
    }
    public async Task<Band> GetBandById(int id)
    {
        return await _context.Bands.Where(b => b.Id == id).FirstOrDefaultAsync();
        
    }
    public async Task<List<Band>> GetBandByCountry(string Country)
    {
        return await _context.Bands.Where(b=>b.Country==Country).ToListAsync();
    }

    //Post
    public async Task<Band> InsertBand(Band example)
    {
        await _context.Bands.AddAsync(example);
        await _context.SaveChangesAsync();
        return example;
    }
    //Put
    public async Task<Band> UpdateBand(Band Band,int id)
    {
        var band_to_change = await _context.Bands.Where(b => b.Id == id).FirstOrDefaultAsync();
        if (band_to_change is null)
        {
            throw new InvalidIdException("Band was not found, There is no band with id you entered");
        }

        else if (Band.Country == null || Band.Name == null)
        {
            throw new ArgumentException("Country or Name was not added");
        }
            
        band_to_change.Country = Band.Country;
        band_to_change.Name = Band.Name;

        await _context.SaveChangesAsync();
        return (band_to_change);
    }
    //Delete
    public async Task DeleteBandById(int id)
    {
        var deleted = await GetBandById(id);
        _context.Bands.Remove(deleted);
        await _context.SaveChangesAsync();

        

    }
}