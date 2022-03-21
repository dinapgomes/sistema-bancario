using System;

public class Conta : IComparable<Conta> {
  private int id;
  private double saldo;
  private int conta_;
  public int Id {get => id; set => id = value;}
  public double Saldo {get => saldo; set => saldo = value;}
  public int conta {get => conta_; set => conta_ = value;}

  public Conta() {}
  
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

  public int CompareTo(Conta obj){
    return this.conta.CompareTo(obj.conta);
  }
}