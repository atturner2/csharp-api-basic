Basic Architecture/Overview:

The controllers create routes which, when called, call the services. The services access the data transfer objects, 
which are used to protect/limit what operations can be performed by the user, this is why there are different data transfer
objects for different operations. (Updating an object vs. creating a new one)

The automapper is pretty nice but is not crucial