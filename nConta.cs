using System;
using System.Collections.Generic;

class NConta {
  private List<Conta> contas = new List<Conta>();
  
  public void Abrir() {
    Arquivo<List<Conta>> f = new Arquivo<List<Conta>>();
    contas = f.Abrir("./contas.xml");
  }

  public void Salvar() {
    Arquivo<List<Conta>> f = new Arquivo<List<Conta>>();
    f.Salvar("./contas.xml", Listar());
  }
  
  public List<Conta> Listar() {
    contas.Sort();
    return contas;
  }

  public Conta Listar(int id) {
    for (int i = 0; i < contas.Count; i++)
      if (contas[i].Id == id) return contas[i];
    return null;  
  }

  public void Inserir(Conta c) {
    int max = 0;
    foreach(Conta obj in contas)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;      
    contas.Add(c);
  } 

  public void Atualizar(Conta c) {
    Conta c_atual = Listar(c.Id);
    if (c_atual == null) return;
    c_atual.Saldo = c.Saldo;
    c_atual.conta = c.conta;
  } 

  public void Excluir(Conta c) {
    if (c != null) contas.Remove(c);
  }
}