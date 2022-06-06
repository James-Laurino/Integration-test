
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

public class UnitTest2
{
    
    /******************** Post() ********************/
    /*************************************************/
    [Theory]
    [InlineData("/api/JWTTokenControler")]
    public async Task Check_JWTPostBadRequest(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le User
        User user = new User();
        user.UserName = "BadName";
        user.Password = "BadMotDePasse";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string UserJSonString = JsonSerializer.Serialize<User>(user, optionsIdentation);
        var stringContent = new StringContent(UserJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/JWTTokenControler", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/JWTTokenControler")]
    public async Task Check_JWTPostBadUserName(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le User
        User user = new User();
        user.UserName = "BadName";
        user.Password = "admin";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string UserJSonString = JsonSerializer.Serialize<User>(user, optionsIdentation);
        var stringContent = new StringContent(UserJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/JWTTokenControler", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/JWTTokenControler")]
    public async Task Check_JWTPostBadUserPasword(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le User
        User user = new User();
        user.UserName = "admin";
        user.Password = "BadMotDePasse";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string UserJSonString = JsonSerializer.Serialize<User>(user, optionsIdentation);
        var stringContent = new StringContent(UserJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/JWTTokenControler", stringContent);
 
        // Assert -> cause of bearer Token
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/JWTTokenControler")]
    public async Task Check_JWTPost(string url)
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>{});

        // désérialiser le User
        User user = new User();
        user.UserName = "admin";
        user.Password = "admin";

        // Arrange
        var Client = application.CreateClient();
        var optionsIdentation = new JsonSerializerOptions { WriteIndented = true };

        string UserJSonString = JsonSerializer.Serialize<User>(user, optionsIdentation);
        var stringContent = new StringContent(UserJSonString, System.Text.Encoding.UTF8 ,"application/json");

        // Act
        var response = await Client.PostAsync("http://localhost:7295/api/JWTTokenControler", stringContent);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}