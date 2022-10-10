namespace ArabiaCellSms.Models;

public class SmsDto
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string Msisdn { get; set; }

    public string Text { get; set; }

    public string Header { get; set; }

    public int MessageTypeId { get; set; }
}