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


public class UnitTest3 
{
    
    /******************** GetAll() ********************/
    /*************************************************/
    [Theory]
    [InlineData("/api/DbUser/GetAll")]
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
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

    [Theory]
    [InlineData("/api/DbUser/GetOne")]
    public async Task Check_GetOne(string url)
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
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

    [Theory]
    [InlineData("/api/DbUser/GetAllInformation")]
    public async Task Check_GetAllInformation(string url)
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
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

    [Theory]
    [InlineData("/api/DbUser/Add")]
    public async Task Check_Add(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le SP
        User user = new User();

        user.Password = "1234";
        user.UserName = "Name Add";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string SuperHeroJSonString = JsonSerializer.Serialize<User>(user, optionsIdentation);
        var stringContent = new StringContent(SuperHeroJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/DbUser/Add", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

    [Theory]
    [InlineData("/api/DbUser/Update")]
    public async Task Check_Update(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le SP
        User user = new User();
        user.UserId = 1;
        user.Password = "password-update";
        user.UserName = "name-update";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string SuperHeroJSonString = JsonSerializer.Serialize<User>(user, optionsIdentation);
        var stringContent = new StringContent(SuperHeroJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PutAsync("http://localhost:7295/api/DbUser/Update", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        
    }

    [Theory]
    [InlineData("/api/DbUser/DeleteById", "1")]
    public async Task Check_DeleteById(string url, string id)
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