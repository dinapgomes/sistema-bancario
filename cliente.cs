using System;

class Cliente {
  private int id;
  private string nome;
  private int idade;
  
  public Cliente(int id, string nome, int idade){
    this.id = id;
    this.nome = nome;
    this.idade = idade;
  }

  public override string ToString(){
    return id + " - " + nome + " - " + idade;
  }
}