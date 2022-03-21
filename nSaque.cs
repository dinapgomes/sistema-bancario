using System;
using System.Collections.Generic;
using System.Linq;

class NSaque {
  private List<Saque> saques = new List<Saque>();

  public void Abrir() {
    Arquivo<List<Saque>> f = new Arquivo<List<Saque>>();
    saques = f.Abrir("./saques.xml");
  }

  public void Salvar() {
    Arquivo<List<Saque>> f = new Arquivo<List<Saque>>();
    f.Salvar("./saques.xml", Listar());
  }
  
  public List<Saque> Listar() {
    return saques;
  }

  public Saque Listar(int id) {
    for (int i = 0; i < saques.Count; i++)
      if (saques[i].Id == id) return saques[i];
    return null;  
  }

  public void Inserir(Saque s) {
    int max = saques.Max(s => s.Id);
    s.Id = max + 1;      
    saques.Add(s);
  } 

  public void Atualizar(Saque s) {
    Saque s_atual = Listar(s.Id);
    if (s_atual == null) return;
    s_atual.Data = s.Data;
    s_atual.Valor = s.Valor;
    s_atual.ContaOrigem = s.ContaOrigem;
    }

  public void Excluir(Saque s) {
    if (s != null) saques.Remove(s);
  }
}