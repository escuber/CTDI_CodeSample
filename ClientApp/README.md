This is the angular client application created for the CTDI sample application.

It would be nice to have automated development tests, but this seemed out-of-scope
for this assignment and I have not done them in VS Code.  They are not being used.

This client is created to rely on the back-end providing the data.  Because the client 
and server are built into one project and run together I saw no advantage to swap out 
mock components for the api calls.

This was developed to run on port 8099.  If this port is not good for your machine
please change in in the client code 
at: ClientApp/src/app/products/product.services.ts 
the top of the code you will see the address.

You will also need to change the server side port at Properties/launchSettings.json
