using System;

class Transferencia{
  public int id { get; set; }
  public string data { get; set; }
  public double valor { get; set; }
  public int contaOrigem { get; set; }
  public int contaDestino { get; set; }
  
  public Transferencia(int id, string data, double valor, int contaOrigem, int contaDestino){
    this.id = id;
    this.data = data;
    this.valor = valor;
    this.contaOrigem = contaOrigem;
    this.contaDestino = contaDestino;
  }

  public void reverterTrasnferencia(){
    
  }

  public override string ToString(){
    return id + " - " + data + " - " + valor + " - " + contaOrigem + " - " + contaDestino;
  }
}