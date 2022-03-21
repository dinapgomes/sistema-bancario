using System;

public class Transferencia{
  private int id;
  private string data;
  private double valor;
  private int contaOrigem;
  private int contaDestino;
  public int Id {get => id; set => id = value;}
  public string Data {get => data; set => data = value;}
  public double Valor {get => valor; set => valor = value;}
  public int ContaOrigem {get => contaOrigem; set => contaOrigem = value;}
  public int ContaDestino {get => contaDestino; set => contaDestino = value;}

  public Transferencia() {}
  
  public Transferencia(int id, string data, double valor, int contaOrigem, int contaDestino){
    this.id = id;
    this.data = data;
    this.valor = valor;
    this.contaOrigem = contaOrigem;
    this.contaDestino = contaDestino;
  }

  public override string ToString(){
    return id + " - " + data + " - " + valor + " - " + contaOrigem + " - " + contaDestino;
  }
}