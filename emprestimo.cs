using System;

class Emprestimo {
  public int id {get; set;}
  public string data {get; set;}
  public double valor {get; set;}
  public int contaOrigem {get; set;}
  public int qtdParcelas {get; set;}
  
  public Emprestimo(int id, string data, double valor, int contaOrigem, int qtdParcelas){
    this.id = id;
    this.data = data;
    this.valor = valor;
    this.contaOrigem = contaOrigem;
    this.qtdParcelas = qtdParcelas;
  }

  public override string ToString(){
    return id + " - " + data + " - " + valor + " - " + contaOrigem + " - " + qtdParcelas;
  }
}