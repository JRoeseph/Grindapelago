///////////////////////////////////////////////////////////////////////////////
///
/// File: ArchiConnector.cs
/// Author: JRoeseph
/// Description: The main class that handles maintaining the connection to 
///     the Archipelago server, sending location checks, and receiving items.
/// 
///////////////////////////////////////////////////////////////////////////////

public static class ArchiConnector
{
    public static void CheckLocation(string LocationDiscovered)
    {
        //DEBUG/TEST CODE
        Grindapelago.GetVanillaItem(LocationDiscovered);
    }
}