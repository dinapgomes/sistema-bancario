using System;
using System.Collections.Generic;

class NEmprestimo {
  private List<Emprestimo> emprestimos = new List<Emprestimo>();

  public List<Emprestimo> Listar() {
    return emprestimos;
  }

  public Emprestimo Listar(int id) {
    for (int i = 0; i < emprestimos.Count; i++)
      if (emprestimos[i].id == id) return emprestimos[i];
    return null;  
  }

  public void Inserir(Emprestimo e) {
    int max = 0;
    foreach(Emprestimo obj in emprestimos)
      if (obj.id > max) max = obj.id;
    e.id = max + 1;      
    emprestimos.Add(e);
  } 

  public void Atualizar(Emprestimo e) {
    Emprestimo e_atual = Listar(e.id);
    if (e_atual == null) return;
    e_atual.data = e.data;
    e_atual.valor = e.valor;
    e_atual.contaOrigem = e.contaOrigem;
    e_atual.qtdParcelas = e.qtdParcelas;
    }

  public void Excluir(Emprestimo e) {
    if (e != null) emprestimos.Remove(e);
  }
}