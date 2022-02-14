using System;
using System.Collections.Generic;

class NTransferencia {
  private List<Transferencia> transferencias = new List<Transferencia>();

  public List<Transferencia> Listar() {
    return transferencias;
  }

  public Transferencia Listar(int id) {
    for (int i = 0; i < transferencias.Count; i++)
      if (transferencias[i].id == id) return transferencias[i];
    return null;  
  }

  public void Inserir(Transferencia t) {
    int max = 0;
    foreach(Transferencia obj in transferencias)
      if (obj.id > max) max = obj.id;
    t.id = max + 1;      
    transferencias.Add(t);
  } 

  public void Atualizar(Transferencia t) {
    Transferencia t_atual = Listar(t.id);
    if (t_atual == null) return;
    t_atual.data = t.data;
    t_atual.valor = t.valor;
    t_atual.contaOrigem = t.contaOrigem;
    t_atual.contaDestino = t.contaDestino;
    }

  public void Excluir(Transferencia t) {
    if (t != null) transferencias.Remove(t);
  }
}