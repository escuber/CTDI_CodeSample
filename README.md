This is the server side application created for the CTDI sample application.  The 
anglar client is located within this application.  It can be found in the clientapp folder

It would be nice to have automated development tests, but this seemed out-of-scope
for this assignment and I have not done them in VS Code.  They are not being used.

This server side api is written using the .net core framework.  To build and run this 
application please install the .net core sdk 
     https://dotnet.microsoft.com/download

Then to run the project:
        open the project in vs core and in a terminal window 
                    to build type: dotnet build
                    to run the project type: dotnet run 

Then bring up the project in your browser: localhost:8099


This was developed to run on port 8099.  If this port is not good for your machine
please change in in the client code 
at: ClientApp/src/app/products/product.services.ts 
the top of the code you will see the address.

You will also need to change the server side port at Properties/launchSettings.json

I chose to use core for this assignment because I have been using it and I am pleased with the platform. For this project
why it made the most sense was because of the dependency injection built into the framework.  To provide for this to be 
utilized I did not create a simple mock datasource.  I used a full entity framework data context.  The reason I did this is 
because the data provider can now be changed to sql or oracle without the need to change any logic.  I think that is very
cool.
