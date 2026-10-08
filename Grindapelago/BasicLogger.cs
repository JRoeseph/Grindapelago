///////////////////////////////////////////////////////////////////////////////
///
/// File: BasicLogger.cs
/// Author: JRoeseph
/// Description: A basic logger because I didn't want to import one
/// 
///////////////////////////////////////////////////////////////////////////////
using SoG;
using System;
using System.IO;
public enum LoggerVerbosity
{
    Error = 0,
    UserChecks = 1,
    AllChecks = 2,
}

public static class Logger
{
    private static StreamWriter LogFile;
    public static void Init()
    {
        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchiLogs"));
        LogFile = File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchiLogs",$"log-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt"));
        LogFile.AutoFlush = true;
        if (LogFile.BaseStream is FileStream fileStream)
        {
            Console.Out.WriteLine($"[Logger] Logger created file at '{fileStream.Name}'");
        }
        else
        {
            Console.Out.WriteLine("[Logger] Failed to create log file");
        }
    }

    public static void Log(string Message, LoggerVerbosity Verbosity)
    {
        if (Grindapelago.ChatVerbosity >= Verbosity)
        {
            try
            {
                CAS.AddChatMessage(Message);
            }
            // Logs that are called BEFORE the game starts throw errors here, so just ignore them
            catch{}
        }
        if (Grindapelago.ConsoleVerbosity >= Verbosity)
        {
            if (Verbosity == LoggerVerbosity.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Out.WriteLine(Message);
                Console.ResetColor();
            }
            else
            {
                Console.Out.WriteLine(Message);
            }
        }
        if (Grindapelago.LogFileVerbosity >= Verbosity)
        {
            LogFile.WriteLine(Message);
        }
    }
}