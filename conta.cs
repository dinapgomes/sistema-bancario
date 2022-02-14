using System;

class Conta{
  public int id {get; set;}
  public double saldo {get; set;}
  public int conta {get; set;}

  public Conta(int id, double saldo, int conta){
    this.id = id;
    this.saldo = saldo;
    this.conta = conta;
  }

  public void depositar(double valor){
    saldo = saldo + valor;
  }

  public void sacar(double valor){
    saldo = saldo - valor;
  }
  
  public override string ToString(){
    return id + " - " + saldo + " - " + conta;
  }
}