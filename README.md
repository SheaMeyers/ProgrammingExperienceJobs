# ProgrammingExperienceJobsApp

A job site for filtering jobs based on programming experience

## Quickstart

Use the steps below when setting up this project for the first time.
These steps are intended to allow you to quickly run the project.

1. Clone the repository
2. Create the database and database user as specified in the `appsettings.json`
3. Go into the `ProgrammingExperienceJobsApp` directory and run `dotnet ef database update` in order to setup the database
4. Run `dotnet run` to start the project
5. Go to `https://localhost:7204/`

## Seed Data

This project comes with data to seed the database with so that when first running the project your database will already have stock information.  To turn this off you can update the `SeedData` attribute in `appsettings.json` to `false`

## Testing

Run `dotnet test` to run the unit tests in this project
