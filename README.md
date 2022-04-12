# JWTdotnetCore5.API
In this repository i implement JWT Authentication in Asp.net Core in web api.
the steps of implementation are below:

* Create Asp.net Core Web API project
* Install NuGet Package (JwtBearer)
* Asp.net Core JWT appsetting.json configuration
* Asp.net Core Startup.cs - configure services add JwtBearer
* Create Models User, Tokens
* Create JWTManagerRepository to Authenticate users and generate JSON Web Token.
* Create UserController - Authenticate action method.

 In the below image, I illustrate the JWT Authentication flow diagram in Asp.net Core Web API:

![image](https://user-images.githubusercontent.com/34911292/163063481-35501367-aae0-4d2f-a0e8-ef932f7cbc12.png)

