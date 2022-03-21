using System;

public class Emprestimo {
  private int id;
  private string data;
  private double valor;
  private int contaOrigem;
  private int qtdParcelas;
  public int Id {get => id; set => id = value;}
  public string Data {get => data; set => data = value;}
  public double Valor {get => valor; set => valor = value;}
  public int ContaOrigem {get => contaOrigem; set => contaOrigem = value;}
  public int QtdParcelas {get => qtdParcelas; set => qtdParcelas = value;}

  public Emprestimo() {}
  
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