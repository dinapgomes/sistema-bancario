using System;
using System.Collections.Generic;

class NSaque {
  private List<Saque> saques = new List<Saque>();

  public List<Saque> Listar() {
    return saques;
  }

  public Saque Listar(int id) {
    for (int i = 0; i < saques.Count; i++)
      if (saques[i].id == id) return saques[i];
    return null;  
  }

  public void Inserir(Saque s) {
    int max = 0;
    foreach(Saque obj in saques)
      if (obj.id > max) max = obj.id;
    s.id = max + 1;      
    saques.Add(s);
  } 

  public void Atualizar(Saque s) {
    Saque s_atual = Listar(s.id);
    if (s_atual == null) return;
    s_atual.data = s.data;
    s_atual.valor = s.valor;
    s_atual.contaOrigem = s.contaOrigem;
    }

  public void Excluir(Saque s) {
    if (s != null) saques.Remove(s);
  }
}