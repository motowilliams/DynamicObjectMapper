## DynamicObjectMapper ##

I've always to make a simple mapper that was based on json or some other flat file accessible from the web so that configuration could be created easily from a web page.

Basically you new up the DynamicObjectMapper and on the map method you pass in a simple instance (*read-as: pretty much a flat object*) and with some JSON deserialized to some Mapper config objects you have a new System.Dynamic object to play with.

You have simple map commands for the following:

 - **Direct field map**
 - **Concat fields**
 - **Flatten simple lists to csv**
 - **Add**
 - **Subtract**
 - **Multiply**
 - *Divide (just haven't done it yet)*
 - *No conditionals are supported yet but I figure as soon as I figure that out it will have been a rewrite to F# anyways.*
