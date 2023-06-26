namespace claimbased.Data.DTOs;


public class AccountDToOut

{

    public int id { get;set;}

    public string AccountName {get; set;} =null!;

    public string ClientName {get; set;} = null!;

    public decimal Balance {get;set;}

    public DateTime RegDate {get;set;}

}