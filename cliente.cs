using System;

public class Cliente {
  private int id;
  private string nome;
  private int idade;
  public int Id { get => id; set => id = value; }
  public string Nome { get => nome; set => nome = value; }
  public int Idade { get => idade; set => idade = value; }
  public Cliente() { }
  
  public Cliente(int id, string nome, int idade){
    this.id = id;
    this.nome = nome;
    this.idade = idade;
  }

  public override string ToString(){
    return id + " - " + nome + " - " + idade;
  }
}