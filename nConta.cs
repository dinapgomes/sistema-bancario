using System;
using System.Collections.Generic;

class NConta {
  private List<Conta> contas = new List<Conta>();

  public List<Conta> Listar() {
    return contas;
  }

  public Conta Listar(int id) {
    for (int i = 0; i < contas.Count; i++)
      if (contas[i].id == id) return contas[i];
    return null;  
  }

  public void Inserir(Conta c) {
    int max = 0;
    foreach(Conta obj in contas)
      if (obj.id > max) max = obj.id;
    c.id = max + 1;      
    contas.Add(c);
  } 

  public void Atualizar(Conta c) {
    Conta c_atual = Listar(c.id);
    if (c_atual == null) return;
    c_atual.saldo = c.saldo;
    c_atual.conta = c.conta;
  } 

  public void Excluir(Conta c) {
    if (c != null) contas.Remove(c);
  }
}