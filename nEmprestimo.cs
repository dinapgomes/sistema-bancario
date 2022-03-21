using System;
using System.Collections.Generic;

class NEmprestimo {
  private List<Emprestimo> emprestimos = new List<Emprestimo>();

  public void Abrir() {
    Arquivo<List<Emprestimo>> f = new Arquivo<List<Emprestimo>>();
    emprestimos = f.Abrir("./emprestimos.xml");
  }

  public void Salvar() {
    Arquivo<List<Emprestimo>> f = new Arquivo<List<Emprestimo>>();
    f.Salvar("./emprestimos.xml", Listar());
  }
  
  public List<Emprestimo> Listar() {
    return emprestimos;
  }

  public Emprestimo Listar(int id) {
    for (int i = 0; i < emprestimos.Count; i++)
      if (emprestimos[i].Id == id) return emprestimos[i];
    return null;  
  }

  public void Inserir(Emprestimo e) {
    int max = 0;
    foreach(Emprestimo obj in emprestimos)
      if (obj.Id > max) max = obj.Id;
    e.Id = max + 1;      
    emprestimos.Add(e);
  } 

  public void Atualizar(Emprestimo e) {
    Emprestimo e_atual = Listar(e.Id);
    if (e_atual == null) return;
    e_atual.Data = e.Data;
    e_atual.Valor = e.Valor;
    e_atual.ContaOrigem = e.ContaOrigem;
    e_atual.QtdParcelas = e.QtdParcelas;
    }

  public void Excluir(Emprestimo e) {
    if (e != null) emprestimos.Remove(e);
  }
}