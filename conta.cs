using System;

class Conta{
  private int id;
  private double saldo;
  private int conta;
  private Transferencia[] transferencias = new Transferencia[50];
  private int nt;

  public Conta(int id, double saldo, int conta){
    this.id = id;
    this.saldo = saldo;
    this.conta = conta;
  }

  public Conta(int id, double saldo, int conta, Transferencia[] trans) : this(id, saldo, conta) {
    this.transferencias = transferencias;
  }

  public Transferencia[] listarTransferencias(){
    return transferencias;
  }

  public void inserirTransferencia(Transferencia t){
    transferencias[nt] = t;
    nt++;
  }

  public Transferencia transferir(double valor, Conta contaDestino) {
    saldo = saldo - valor;
    contaDestino.depositar(valor);
    Transferencia t = new Transferencia(1,"11/12/2021", valor, conta, contaDestino.getConta());

    inserirTransferencia(t);
    return t;
  }

  public void depositar(double valor){
    saldo = saldo + valor;
  }

  public void sacar(double valor){
    saldo = saldo - valor;
  }
  
  public int getId(){
    return id;
  }

  public int getConta(){
    return conta;
  }

  public double getSaldo(){
    return saldo;
  }

  public override string ToString(){
    return id + " - " + saldo + " - " + conta;
  }
}