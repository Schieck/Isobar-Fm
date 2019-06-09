# Isobar-Fm

[![CircleCI](https://circleci.com/gh/Schieck/Isobar-Fm/tree/master.svg?style=svg&circle-token=64299cea5f2be700ebb81e9ab916e90ee4891284)](https://circleci.com/gh/Schieck/Isobar-Fm/tree/master) [![codecov](https://codecov.io/gh/Schieck/Isobar-Fm/branch/master/graph/badge.svg?token=j75w4MBXOL)](https://codecov.io/gh/Schieck/Isobar-Fm) (Core Layer 100%)

A program for our organization favourite bands, albuns and tracks !

## How run the App
- Restore Nuget Packages
`dotnet restore`
- Run
`dotnet run -p Isobar.Fm.Api/Isobar.Fm.Api.csproj`

Isobar Fm Api is now running at: `http://localhost:5000` :seedling:

## Extra Features 
- Swagger 
  - Very easy to test this api, just go to the listening path or to `/swagger` and it will create all the requests for you
  
- Health Check
  - To ferify if the api is healty, just go to `/api/HealthCheck`
  
## Architecture
For this application do we have some layers:

### Api
Where the app start and endpoints are exposed.

### Tests
This is an important layer to be sure that our code have all the scenarios covered and that our application are trustworthy.

#### [Unit Tests](https://codecov.io/gh/Schieck/Isobar-Fm)
This tests are covers the business rules and in this project should cover the Core Layer.

