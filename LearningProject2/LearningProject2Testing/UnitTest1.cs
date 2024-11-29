using LearningProject2.Controllers;
using LearningProject2.Interfaces;
using LearningProject2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningProject2Testing;
using Moq;


[TestFixture]
public class Tests
{
    //Variables needed throughout all tests 
    private Mock<IBandService> _mockBandService;
    private BandController _controller;
    private Band _bandexample;
    private List<Band> _listbandexample;
    
    [SetUp]
    public void Setup()
    {     //Process needed for Mocking
         _mockBandService = new Mock<IBandService>();
         _controller = new BandController(_mockBandService.Object);
         //Other Stuff needed to mock
         _bandexample= new Band();
         _bandexample.Id= 5;
         _listbandexample = new List<Band>();
    }

    /// <summary>
    /// Testing Get Methods
    /// Only testing Get All Bands and Get All Bands by id
    /// </summary>
    [Test,Category("GetMethod")]
    public async Task ConsultAllBands_ShouldReturnOk_WhenBandsExistOnList()
    {
        //Arrange
        
        _listbandexample.Add(_bandexample);
        
        _mockBandService.Setup(service => service.ConsultAllBands())
            .ReturnsAsync(_listbandexample);
        //Act
        var result = await _controller.ConusltAllBands();
        var realvalue = result as OkObjectResult;
        
        //Assert
        Assert.NotNull(result);
        Assert.That(result,Is.InstanceOf<OkObjectResult>());
        Assert.That(_listbandexample, Is.EqualTo(realvalue.Value));
        
        
    }

    [Test,Category("GetMethod")]
    public async Task ConsultAllBands_ShouldReturnNotFound_WhenBandsDoNotExistOnList()
    {
        //Arrange
        _mockBandService.Setup(service => service.ConsultAllBands())
            .ReturnsAsync(_listbandexample);
        //Act
        var result = await _controller.ConusltAllBands();
     
        //Assert
        
        Assert.That(result,Is.InstanceOf<NotFoundObjectResult>());
        
    }

    [Test,Category("GetMethod")]
    public async Task ConsultBandById_ShouldReturnOk_WhenBandExists()
    {
        //Arrange
        _mockBandService.Setup(service => service.ConsultBandById(_bandexample.Id))
            .ReturnsAsync(_bandexample);
        //Act
        var result = await _controller.ConusltBandById(_bandexample.Id);
        var realvalue = result as OkObjectResult;
        
        //Assert
        
        Assert.That(result,Is.InstanceOf<OkObjectResult>());
        Assert.That(_bandexample,Is.EqualTo(realvalue.Value));
        
    }


    /// <summary>
    /// Consult Put Methods
    /// Only testing update bands 
    /// </summary>
    
    [TestCase("Spinetta",null),Category("UpdateMethod")]
    [TestCase(null,"Argentina"),Category("UpdateMethod")]
    public async Task UpdateBands_ShouldReturnBadRequest_WhenNameOrCountryIsMissingFromBandClass(string? name, string? country)
    {
        //Arrange
   
        _bandexample.Name = name;
        _bandexample.Country = country;
        var excpetionMessage = "Invalid Input, you should put name and country in band";
        
        _mockBandService.Setup(service => service.UpdateBand(_bandexample,_bandexample.Id))
            .ThrowsAsync(new ArgumentException(excpetionMessage));
        

        //Act
        var result = await _controller.UpdateBand(_bandexample,_bandexample.Id);
        var realvalue = result as BadRequestObjectResult;
        
        
        //Assert
        Assert.That(excpetionMessage,Is.EqualTo(realvalue.Value));
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
    }
    
}