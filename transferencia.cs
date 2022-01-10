using System;

class Transferencia{
  private int id;
  private string data;
  private double valor;
  private int contaOrigem;
  private int contaDestino;
  
  public Transferencia(int id, string data, double valor, int contaOrigem, int contaDestino){
    this.id = id;
    this.data = data;
    this.valor = valor;
    this.contaOrigem = contaOrigem;
    this.contaDestino = contaDestino;
  }

  public void reverterTrasnferencia(){
    
  }

  public int getId(){
    return id;
  }

  public override string ToString(){
    return id + " - " + data + " - " + valor + " - " + contaOrigem + " - " + contaDestino;
  }
}