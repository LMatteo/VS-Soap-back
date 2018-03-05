#CLIENT

I couldn't make it work using Visual Studio 

Execute Program.exe for the client console app

BikeServiceClient class produced using :

svcutil.exe http://localhost/BikeService?wsdl

##BUILD

use the developer console and in the right folder use :

csc BikeService.cs CommandHandler.cs Program.cs

this will produce the Program.exe

#SOAPBIKE

Use Visual Studio to launch 

#Extension : Cache 

the Cache class in Cache.cs is a container for any type

When instanciated you must specify a refresh time span (in second)

the data is outdated after the specified refresh time

if there is an attemps to get outdated data with the getContent() method, the data is fetched again using the refresh() method

You must inherit the Cache Class and override refresh() to specify how the data will be fetched