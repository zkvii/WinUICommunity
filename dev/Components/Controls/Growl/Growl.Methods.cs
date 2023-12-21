﻿namespace WinUICommunity;
public partial class Growl : InfoBar
{
    public static void Info(string title) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Informational
    });
    public static void InfoGlobal(string title) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Informational
    });
    public static void InfoWithToken(string title, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Informational,
        Token = token
    });
    public static void Info(string title, string message) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Informational
    });
    public static void InfoGlobal(string title, string message) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Informational
    });
    public static void InfoWithToken(string title, string message, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Informational,
        Token = token
    });
    public static void Info(GrowlInfo growlInfo) => InitGrowl(growlInfo, true, InfoBarSeverity.Informational);
    public static void InfoGlobal(GrowlInfo growlInfo) => InitGrowlGlobal(growlInfo, true, InfoBarSeverity.Informational);

    public static void Info2(string title) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Informational,
        UseBlueColorForInfo = true
    });
    public static void Info2Global(string title) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Informational,
        UseBlueColorForInfo = true
    });
    public static void Info2WithToken(string title, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Informational,
        UseBlueColorForInfo = true,
        Token = token
    });
    public static void Info2(string title, string message) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Informational,
        UseBlueColorForInfo = true
    });
    public static void Info2Global(string title, string message) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Informational,
        UseBlueColorForInfo = true
    });
    public static void Info2WithToken(string title, string message, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Informational,
        UseBlueColorForInfo = true,
        Token = token
    });

    public static void Success(string title) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Success
    });
    public static void SuccessGlobal(string title) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Success
    });
    public static void SuccessWithToken(string title, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Success,
        Token = token
    });
    public static void Success(string title, string message) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Success
    });
    public static void SuccessGlobal(string title, string message) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Success
    });
    public static void SuccessWithToken(string title, string message, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Success,
        Token = token
    });
    public static void Success(GrowlInfo growlInfo) => InitGrowl(growlInfo, true, InfoBarSeverity.Success);
    public static void SuccessGlobal(GrowlInfo growlInfo) => InitGrowlGlobal(growlInfo, true, InfoBarSeverity.Success);

    public static void Warning(string title) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Warning
    });
    public static void WarningGlobal(string title) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Warning
    });
    public static void WarningWithToken(string title, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Warning,
        Token = token
    });
    public static void Warning(string title, string message) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Warning
    });
    public static void WarningGlobal(string title, string message) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Warning
    });
    public static void WarningWithToken(string title, string message, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Warning,
        Token = token
    });
    public static void Warning(GrowlInfo growlInfo) => InitGrowl(growlInfo, true, InfoBarSeverity.Warning);
    public static void WarningGlobal(GrowlInfo growlInfo) => InitGrowlGlobal(growlInfo, true, InfoBarSeverity.Warning);

    public static void Error(string title) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Error
    });
    public static void ErrorGlobal(string title) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Error
    });
    public static void ErrorWithToken(string title, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Severity = InfoBarSeverity.Error,
        Token = token
    });
    public static void Error(string title, string message) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Error
    });
    public static void ErrorGlobal(string title, string message) => InitGrowlGlobal(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Error
    });
    public static void ErrorWithToken(string title, string message, string token) => InitGrowl(new GrowlInfo
    {
        Title = title,
        Message = message,
        Severity = InfoBarSeverity.Error,
        Token = token
    });
    public static void Error(GrowlInfo growlInfo) => InitGrowl(growlInfo, true, InfoBarSeverity.Error);
    public static void ErrorGlobal(GrowlInfo growlInfo) => InitGrowlGlobal(growlInfo, true, InfoBarSeverity.Error);
}