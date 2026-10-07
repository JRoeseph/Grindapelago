///////////////////////////////////////////////////////////////////////////////
///
/// File: ArchiConnector.cs
/// Revision: 1
/// Author: JRoeseph
/// Description: The main class that handles maintaining the connection to 
///     the Archipelago server, sending location checks, and receiving items.
/// 
///////////////////////////////////////////////////////////////////////////////
using SoG;
using System;

public static class ArchiConnector
{
    public static void GetVanillaItem(string LocationDiscovered)
    {
        ArchiItem VanillaItem = LocationDictionaries.VanillaItemDictionary[LocationDiscovered];
        VanillaItem.Collect();
        Console.Out.WriteLine("Location Found: " + LocationDiscovered);
        CAS.AddChatMessage("Location Found: " + LocationDiscovered);
    }
}