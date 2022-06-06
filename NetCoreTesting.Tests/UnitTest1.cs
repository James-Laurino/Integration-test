// using NUnit.Framework;



// Http request 
using System.Net.Http;

// Using for connection SuperHero folder
using WebApi.Repository;
using WebApi.Controllers;
using WebApi.Interfaces;
using WebApi.Data;

// System for testing
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

// generic System
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

// Serialization
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace WebApi;

public class UnitTest1
{

    /******************** GetAll() ********************/
    /*************************************************/
    [Theory]
    [InlineData("/api/DbSuperHero/GetAll")]
    public async Task Check_GetAll(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {

        });

        // Arrange
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        
    }

    /******************** GetOne() ********************/
    /*************************************************/
    [Theory]
    [InlineData("/api/DbSuperHero/GetOne", "1")]

    public async Task Check_GetOne(string url, string id)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {

        });

        // Arrange
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync(url + "?id=" + id);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        
    }

    
    
    /******************** GetAllinformation() ********************/
    /*************************************************/
    [Theory]
    [InlineData("/api/DbSuperHero/GetAllInformation", "hulk")]

    public async Task Check_GetAllInformation(string url, string info)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {

        });

        // Arrange
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync(url + "?info=" + info);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        
    }
    
    // /******************** ADD() ********************/
    // /***********************************************/
    [Theory]
    [InlineData("/api/DbSuperHero/Add")]
    public async Task Check_Add(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le SP
        SuperHero sp = new SuperHero();
        sp.HeroName = "Black Widow";
        sp.FirstName = "Natasha";
        sp.LastName = "Romanov";
        sp.Universe = "Marvel";
        sp.Picture = "https://imgsrc.cineserie.com/2021/07/black-widow-2020-comic-poster-wd.jpg?ver=1";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string SuperHeroJSonString = JsonSerializer.Serialize<SuperHero>(sp, optionsIdentation);
        var stringContent = new StringContent(SuperHeroJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/DbSuperHero/Add", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }


    /******************** ADD() ********************/
    /***********************************************/
    [Theory]
    [InlineData("/api/DbSuperHero/Update")]
    public async Task Check_Update(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le SP
        SuperHero sp = new SuperHero();
        sp.Id = 1;
        sp.HeroName = "Black Widow";
        sp.FirstName = "Natasha Update";
        sp.LastName = "Romanov Update";
        sp.Universe = "Marvel";
        sp.Picture = "https://imgsrc.cineserie.com/2021/07/black-widow-2020-comic-poster-wd.jpg?ver=1";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string SuperHeroJSonString = JsonSerializer.Serialize<SuperHero>(sp, optionsIdentation);
        var stringContent = new StringContent(SuperHeroJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/DbSuperHero/Add", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

    /******************** Delete() ********************/
    /*************************************************/
    [Theory]
    [InlineData("/api/DbSuperHero/DeleteById", "1005")]
    public async Task Check_GetDeleteOne(string url, string id)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // Arrange
        var Client = application.CreateClient();

        // Act
        var response = await Client.DeleteAsync(url + "?id=" + id);
 
        // Assert -> cause of Berear token
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

}