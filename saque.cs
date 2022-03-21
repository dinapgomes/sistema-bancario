using System;

public class Saque {
  private int id {get; set;}
  private string data {get; set;}
  private double valor {get; set;}
  private int contaOrigem {get; set;}
  public int Id {get => id; set => id = value;}
  public string Data {get => data; set => data = value;}
  public double Valor {get => valor; set => valor = value;}
  public int ContaOrigem {get => contaOrigem; set => contaOrigem = value;}

  public Saque() {} 
  
  public Saque(int id, string data, double valor, int contaOrigem){
    this.id = id;
    this.data = data;
    this.valor = valor;
    this.contaOrigem = contaOrigem;
  }

  public override string ToString(){
    return id + " - " + data + " - " + valor + " - " + contaOrigem;
  }
}