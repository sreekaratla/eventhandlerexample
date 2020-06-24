This is an example to understand how events, delegates and event handlers work

When you declare an event, you are saying which shape of method (EventHandler) that event will invoke, by specifying a delegate:

~~~~
//This delegate can be used to point to methods
//which return void and take a string.
public delegate void MyEventHandler(string foo);

//This event can cause any method which conforms
//to MyEventHandler to be called.
public event MyEventHandler SomethingHappened;

//Here is some code I want to be executed
//when SomethingHappened fires.
void HandleSomethingHappened(string foo)
{
    //Do some stuff
}

//I am creating a delegate (pointer) to HandleSomethingHappened
//and adding it to SomethingHappened's list of "Event Handlers".
myObj.SomethingHappened += new MyEventHandler(HandleSomethingHappened);
~~~~

(*This is the key to events in .NET and peels away the "magic" - an event is really, under the covers, just a list of methods of the same "shape". The list is stored where the event lives. When the event is "raised", it's really just "go through this list of methods and call each one, using these values as the parameters". Assigning an event handler is just a prettier, easier way of adding your method to this list of methods to be called).

Because the compiler knows the delegate type of the SomethingHappened event, this:

    myObj.SomethingHappened += HandleSomethingHappened;
    
Is totally equivalent to:

    myObj.SomethingHappened += new MyEventHandler(HandleSomethingHappened);
    
And handlers can also be unregistered with -= like this:

    // -= removes the handler from the event's list of "listeners":
    myObj.SomethingHappened -= HandleSomethingHappened;

For completeness' sake, raising the event can be done like this, only in the class that owns the event:

~~~~
//Firing the event is done by simply providing the arguments to the event:
if (SomethingHappened != null) // the event is null if there are no listeners!
{
    SomethingHappened("Hi there!");
}
~~~~
