# Description

This project is a DotNet implementation of Onity's TCP/IP PMS protocol.
It is used to encode magnetic cards and RFID keys using any HT24 door's lock compatible encoder.

For more information about doors locking systems and encoders, please visit https://en.onity.com/products/Pages/Electronic-Locks.aspx


# How to use

You must have a HT24 compatible encoder connected on local and reachable IP address.
Please refer to the encoder user's guide to setup instructions

```c#
Console.WriteLine("Enter room# ");
var room = Console.ReadLine();

try
{
    using (var client = new Client("192.168.1.1", 6669))
    {
        var writeData = new WriteData 
        { 
            EncoderNumber = 1, 
            Room1 = room, 
            InitialDateTime = DateTime.Today, 
            FinalDateTime = DateTime.Today.AddDays(2)
        };

        var uid = client.Write(writeData);
        Console.WriteLine($"Written on {uid} tag");

        Console.WriteLine("Read ... ");

        var readData = new ReadData 
        { 
            EncoderNumber = 1, 
            ExpellingType = EjectionType.E
        };
        
        var read = client.Read();
        Console.WriteLine($"Room {read.Room1} {read.Uid}");
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
```

# Disclaimer

This project is not endorsed or officially supported by Onity.




