# CLIENT

List of command : 

? : print help

quit : end the program

city : display all the cities

bike <city> <station> : return name of the given station in the given city

station <city> : return all the stations of the given city

Use the bike service endpoint provided by the SOAPBike project

# SOAPBIKE

provide BikeService and MonitorService endpoints

Due to the use of WCF the class BikeService and MonitorService are instanciated by the framework. 
So we don't know where and when they are instanciated. In order to share variable the class member are static 


# Extension : Cache 

the Cache class in Cache.cs is a container for any type

When instanciated you must specify a refresh time span (in second) or use default (10 seconds), 
the data is outdated after the specified refresh time. If there is an attemps to get outdated data with the getContent() method, 
the data is fetched again using the refresh() method

You must inherit the Cache Class and override refresh() to specify how the data will be fetched
The Cache objects are used as static class member BikeService

# Extension : Monitoring

The MonitorGUI extension provide a GUI. It displays various informations on the request made by the IWS. 
It also allows to change the cache refresh time. On the IWS side the implementation is made using a lot of static class members. 
A good implementation could use an observer pattern for example.

