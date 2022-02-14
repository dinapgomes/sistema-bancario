using System;

class Saque {
  public int id {get; set;}
  public string data {get; set;}
  public double valor {get; set;}
  public int contaOrigem {get; set;}
  
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